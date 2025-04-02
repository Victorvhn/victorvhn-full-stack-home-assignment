"use client";

import { AlertTriangle } from "lucide-react";

import { Button } from "@/components/ui/button";

interface ErrorStateProps {
  title?: string;
  message?: string;
  reset: () => void;
}

export default function ErrorState({
  title = "Something went wrong!",
  message = "We couldn't complete your request. Please try again.",
  reset,
}: ErrorStateProps) {
  return (
    <div className="mx-auto flex h-screen max-w-md items-center justify-center">
      <div className="border border-red-100 bg-white p-6 shadow-sm">
        <div className="mb-4 flex items-center gap-2 text-red-600">
          <AlertTriangle className="h-5 w-5" aria-hidden="true" />
          <h2 className="text-lg font-medium" id="error-heading">
            {title}
          </h2>
        </div>

        {message && (
          <p className="mb-6 text-sm text-slate-600" id="error-description">
            {message}
          </p>
        )}

        <div className="flex justify-end">
          <Button onClick={() => reset()} aria-describedby="error-heading">
            Try again
          </Button>
        </div>
      </div>
    </div>
  );
}
