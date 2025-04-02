export class ApiError extends Error {
  status: number;
  type: string;
  detail: string;
  errors?: Record<string, string[]>;

  constructor(message: string, status: number, type: string, detail: string, errors?: Record<string, string[]>) {
    super(message);
    this.name = "ApiError";
    this.status = status;
    this.type = type;
    this.detail = detail;
    this.errors = errors;
  }
}
