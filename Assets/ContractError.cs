using System;
public class ContractError
{
    public static bool CheckError(string hash) {
        if (String.Compare("Fail", 0, hash, 0, 4) == 0) {
            Console.WriteLine(hash);
            return true;
        }
        return false;
    }
}
