namespace NarodResolutionUtility
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // close the application if they decline the license agreement
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            welcomeRequirementsForm nextForm = new(); // creates an object with the next form
            nextForm.Show(); // puts this new window on the screen
            Close(); // close the current form
        }
    }
}