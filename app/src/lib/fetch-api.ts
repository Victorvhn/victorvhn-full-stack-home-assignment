import { env } from "process";

import { ApiError } from "@/types/api-error";

export async function fetchApi<T>(url: string | URL, options?: RequestInit): Promise<T> {
  try {
    const requestOptions = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        ...options?.headers,
      },
    };

    if (env.CLIENT_ID) {
      (requestOptions.headers as Record<string, string>)["X-Client-ID"] = env.CLIENT_ID;
    }

    const response = await fetch(url, requestOptions);

    if (response.ok) {
      if (response.status === 204) {
        return {} as T;
      }

      return (await response.json()) as T;
    }

    try {
      const errorData = await response.json();

      throw new ApiError(
        errorData.title || "API Error",
        response.status,
        errorData.type || `https://httpstatuses.com/${response.status}`,
        errorData.detail || response.statusText,
        errorData.errors || {}
      );
    } catch (parseError) {
      if (parseError instanceof SyntaxError) {
        throw new ApiError(
          "API Response Error",
          response.status,
          `https://httpstatuses.com/${response.status}`,
          response.statusText || "Invalid response from the server",
          {}
        );
      }

      throw parseError;
    }
  } catch (error) {
    if (error instanceof ApiError) {
      throw error;
    }

    console.error("Fetch error:", error);
    throw new ApiError(
      "Network Error",
      0,
      "https://developer.mozilla.org/en-US/docs/Web/API/fetch",
      (error as Error)?.message || "Failed to connect to the server",
      {}
    );
  }
}
