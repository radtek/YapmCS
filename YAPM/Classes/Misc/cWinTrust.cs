using System;
using Native.Api;

namespace Security.WinTrust
{
    public class WinTrust
    {

        // GUID of the action to perform
        private static Guid GuidVerifyAction = new Guid(NativeConstants.WintrustActionGenericVerify2);

        // Check file signature
        public static bool VerifyEmbeddedSignature(string fileName)
        {
            NativeStructs.WinTrustData wtd = new NativeStructs.WinTrustData(fileName);
            NativeEnums.WinVerifyTrustResult result = NativeFunctions.WinVerifyTrust(NativeConstants.InvalidHandleValue, GuidVerifyAction, wtd);
            return (result == NativeEnums.WinVerifyTrustResult.Trusted);
        }
        public static NativeEnums.WinVerifyTrustResult VerifyEmbeddedSignature2(string fileName)
        {
            NativeStructs.WinTrustData wtd = new NativeStructs.WinTrustData(fileName);
            return NativeFunctions.WinVerifyTrust(NativeConstants.InvalidHandleValue, GuidVerifyAction, wtd);
        }
    }
}
