namespace symptomSage.BussinesLogic
{
    public class Authentication
    {
        public string StatusMsg;

        public bool Status;

        public Authentication(string statusMsg, bool status)
        {
            StatusMsg = statusMsg;
            Status = status;
        }
    }
}