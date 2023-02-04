# JwtIdentityLibrary

Project extension which includes:
1. Adding authorization and authentication by jwt-token.
1. Generation of a jwt-token.
2. PasswordManager, which returns the hashed password and checks if the received password matches.

# Development

### Reference
Add a reference to the JwtIdentity project in MainProject.csproj
```
<ItemGroup>
        <ProjectReference Include="..\FolderProject\JwtIdentity.csproj" />
</ItemGroup>
```
_or via IDE functions_

### Call the method
In the asp.net main project, in the program.cs file, call the method `AddJwtIdentity`.
```
static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
        .AddJwtIdentity();
}
```

### Using the library
In the class where jwtTokenHelper or PasswordManager is required, inject the input parameters of these classes into the constructor.
```
public UpdateUserHandler(PasswordManager passwordManager, JwtTokenService jwtTokenService)
{
    _passwordManager= passwordManager;
    _jwtTokenService = jwtTokenService;
}
```

### And using this
```
public void UpdatePassword(string enteredPassword)
{
    string hash = _passwordManager.HashPassword(enteredPassword);
    _userRepository.UpdateHashPassword(hash);
}

public void VerifyingPassword(string enteredPassword)
{
    string hash = _userRepository.GetHashPassword();
    PasswordVerificationResult result = _passwordManager.VerifyPassword(hash, enteredPassword);
}

public string GetToken(IIdentityUser user)
{
    return = _jwtTokenService.GetToken(user);
}
```
