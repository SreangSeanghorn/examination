using System;

namespace OnlineExam.Application.Common;

public record BaseResponse<T>(
    bool IsSuccess,
    string Message,
    T Data
)
{

}
