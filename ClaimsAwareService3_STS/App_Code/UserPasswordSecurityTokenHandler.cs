using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.Linq;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Protocols.WSIdentity;

public class UserPasswordSecurityTokenHandler : Microsoft.IdentityModel.Tokens.UserNameSecurityTokenHandler
{
    public override bool CanValidateToken
    {
        get { return true; }
    }

    public override ClaimsIdentityCollection ValidateToken(SecurityToken token)
    {
        //throw new Exception();
        var userToken = token as UserNameSecurityToken;

        if (userToken == null)
            throw new ArgumentNullException("token");

        if (userToken.UserName == "admin" && userToken.Password == "pass")
        {
            IClaimsIdentity identity = new ClaimsIdentity();
            var claim = new Claim(WSIdentityConstants.ClaimTypes.Name, userToken.UserName);
            claim.Properties.Add("Site", "SmartDrive");
            identity.Claims.Add(claim);
            return new ClaimsIdentityCollection(new IClaimsIdentity[] { identity });
        }

        throw new InvalidOperationException("The username/password is incorrect");
        return new ClaimsIdentityCollection(new List<ClaimsIdentity>().AsReadOnly());
    }

    public override Type TokenType
    {
        get { return typeof (UserNameSecurityToken); }
    }
}
