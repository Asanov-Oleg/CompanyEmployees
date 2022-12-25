using System.IdentityModel.Tokens.Jwt;

namespace Repository
{
    internal class JwtSecurityTokenHandler
    {
        public JwtSecurityTokenHandler()
        {
        }

        internal class WriteToken
        {
            private JwtSecurityToken tokenOptions;

            public WriteToken(JwtSecurityToken tokenOptions)
            {
                this.tokenOptions = tokenOptions;
            }
        }
    }
}