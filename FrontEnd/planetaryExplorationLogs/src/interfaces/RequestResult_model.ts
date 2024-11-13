export interface requestResult<T>
{
    success: boolean;
    message: string;
    data: T;
}