namespace Sam.Wrappers
{
    public enum ErrorCode : short
    {
        // 1xx: Informational
        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102, // WebDAV

        // 2xx: Success
        Ok = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207, // WebDAV
        AlreadyReported = 208, // WebDAV
        ImUsed = 226, // Delta encoding

        // 3xx: Redirection
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        TemporaryRedirect = 307,
        PermanentRedirect = 308,

        // 4xx: Client Errors
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        PayloadTooLarge = 413,
        UriTooLong = 414,
        UnsupportedMediaType = 415,
        RangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        ImATeapot = 418, // Fun HTTP status code
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,

        // 5xx: Server Errors
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        NotExtended = 510,
        NetworkAuthenticationRequired = 511,

        // Custom Application Errors
        ModelStateNotValid = 600,
        FieldDataInvalid = 601,
        AccessDenied = 602,
        ErrorInIdentity = 603,
        Exception = 604,
        UnknownError = 605,
        RequestAborted = 606,
        DependencyError = 607,
        ValidationFailed = 608,
        ResourceLocked = 609,
        OperationFailed = 610,
        DataConflict = 611,
        RateLimitExceeded = 612,
        AuthenticationFailed = 613, // Authentication failed due to invalid credentials
        AuthorizationFailed = 614, // User is not authorized to perform the requested action
        FeatureNotSupported = 615, // Requested feature is not supported
        DataIntegrityError = 616, // Error related to data integrity
        Timeout = 617, // Operation or request timed out
        MaintenanceMode = 618, // System is currently under maintenance
        DeprecatedApi = 619, // API endpoint is deprecated and should not be used
        ExternalServiceError = 620 // Error from an external service dependency
    }
}
