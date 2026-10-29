namespace Apitest.Common;

public class ResourceNotFoundException(string message) : Exception(message);
public class BusinessRuleException(string message) : Exception(message);
public class DataConflictException(string message) : Exception(message);
