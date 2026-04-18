using Breadboard.Application.Exceptions.Models;

namespace Breadboard.Presentation.ExceptionHandler.Exceptions;

public sealed class ValidationException(List<ExceptionDetail> errors) : ApiExceptionBase(errors);