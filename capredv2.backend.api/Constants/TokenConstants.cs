namespace capredv2.backend.api.Constants
{
    public class TokenConstants
    {
        //To generate another Salt paste the code below in LinqPad (you can change the salt size by changing it into byte 512 or 1024
        //var random = new System.Security.Cryptography.RNGCryptoServiceProvider();
        //var salt = new byte[256];
        //random.GetBytes(salt);
        //Convert.ToBase64String(salt).Dump();
        public const string TokenSalt =
            "Ha0gW8UasCpnrJntioihGpkb4by0+wPk92NtH3SqeQRQy40YVAddOHwgXDTYUE8CQ7+tZbF2Ks0RoAHfJqJ0/C/zVz6FEB0lmXrcB3Kp0A7JOvNvhbsBXqXpPDMtzYDfCV9y/k9jdShz+cjzzikdZoiTLhDP2z9XULxLQFBZhaDLrIaoJw58YxZ3QEArlmbMz0Gf+fAYgTkJDrj1TIs4UIkO5ukzvqDBxgE2EKdbCkUbuEHdsRnpOxd4D6ikPM1trfa1BzAsh63aQKfgZXAXd5qgXE/NQLhWG9Pr3QNQKfMC6OaoMqw4Ec2Ju26zLGswWpM0gx1romHsnk9iddHBuQ==";
    }
}
