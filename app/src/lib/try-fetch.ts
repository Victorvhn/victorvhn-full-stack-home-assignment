import { ApiError } from "@/types/api-error";

export type Result<T> = {
  data: T | null;
  error: ApiError | null;
  isSuccess: boolean;
  isFailure: boolean;
};

export async function tryFetch<T>(promise: Promise<T>): Promise<Result<T>> {
  try {
    const data = await promise;
    return {
      data,
      error: null,
      isSuccess: true,
      isFailure: false,
    };
  } catch (error) {
    return {
      data: null,
      error: error as ApiError,
      isSuccess: false,
      isFailure: true,
    };
  }
}
