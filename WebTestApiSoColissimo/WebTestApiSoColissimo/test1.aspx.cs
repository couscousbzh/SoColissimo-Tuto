using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace WebTestApiSoColissimo
{
    public partial class test1 : System.Web.UI.Page
    {

        private int account = 0;
        private int password = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblDebug.Text = "";


                lblDebug.Text += "Test SoColissimo...<br>";
                lblDebug.Text += "..............................................................................................................<br><br>";

                lblDebug.Text += "Initiating ...<br>";

                SWSoColissimo.WSColiPosteLetterServiceClient client = new SWSoColissimo.WSColiPosteLetterServiceClient();


                SWSoColissimo.AddressVO addressVO = new SWSoColissimo.AddressVO();
                addressVO.companyName = "Reactor";
                addressVO.line1 = "2 la Grée";
                addressVO.postalCode = "35580";
                addressVO.city = "Guignen";


                SWSoColissimo.LetterVO letter = new SWSoColissimo.LetterVO();

                letter.contractNumber = account;
                letter.contractNumber = password;

                letter.dest = new SWSoColissimo.DestEnvVO();
                letter.dest.addressVO = addressVO;

                //Faire un test de disponibilité du service 

                lblDebug.Text += "Try to request for a letter<br>";

                SWSoColissimo.ReturnLetterVO returnLetterVO = client.getLetter(letter);

                lblDebug.Text += "Done<br>";

                lblDebug.Text += returnLetterVO.PdfUrl;
            }
            catch (Exception ex)
            {
                lblDebug.Text += "ERROR<br>";
                while (ex != null)
                {
                    lblDebug.Text += ex.Message + "<br>";
                    ex = ex.InnerException;                
                }
            
            }

        }
    }
}