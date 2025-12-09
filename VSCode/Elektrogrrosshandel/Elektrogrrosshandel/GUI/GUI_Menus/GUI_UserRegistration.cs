// """

using Spectre.Console;

namespace Elektrogrosshandel.GUI.GUI_Menus
{
    internal class GUI_UserRegistration
    {

        private static Layout UserRegistrationMenu(string FirstName, string LastName, string FirmName, string Email, string PhoneNumber,
                                                    string UserName, string SerialCode, string Password)
        {
            Layout userRegistrationMenu = new Layout("User Registration")
                .SplitColumns(
                    new Layout("User").Size(35)
                         .SplitRows(
                            new Layout("PersonalInformaion"),
                            new Layout("AccountInformation")),
                new Layout("Information").Size(85));

            userRegistrationMenu["PersonalInformaion"].Update(PanelPersonalInformation(FirstName, LastName, FirmName, Email, PhoneNumber).Expand());
            userRegistrationMenu["AccountInformation"].Update(PanelAccountInformation(UserName, SerialCode, Password).Expand());

            userRegistrationMenu["Information"].Update(DisplayInformation());

            return userRegistrationMenu;
        }

        private static Panel PanelPersonalInformation(string FirstName, string LastName, string FirmName, string Email, string PhoneNumber)
        {
            Panel panelPersonalInformation = new Panel(
                Align.Left(new Markup($"[#c0c0c0]  First Name:[/] [white]{FirstName}[/]" +
                                        $"\n[#c0c0c0]  Last Name:[/] [white]{LastName}[/]" +
                                        $"\n[#c0c0c0]  Firm Name:[/] [white]{FirmName}[/]" +
                                        $"\n[#c0c0c0]  Email:[/] [white]{Email}[/]" +
                                        $"\n[#c0c0c0]  Phone Number:[/] [white]{PhoneNumber}[/]"), VerticalAlignment.Middle));

            panelPersonalInformation.Height = 11;
            panelPersonalInformation.Width = 60;
            panelPersonalInformation.Border(BoxBorder.Rounded);
            panelPersonalInformation.BorderColor(Color.DarkGoldenrod);
            panelPersonalInformation.Header("[bold #af8700 on black]Personal Information[/]");
            panelPersonalInformation.HeaderAlignment(Justify.Left);
            return panelPersonalInformation;
        }

        private static Panel PanelAccountInformation(string UserName, string SerialCode, string Password)
        {
            Panel panelAccountInformation = new Panel(
                Align.Left(new Markup($"[#c0c0c0]  User Name:[/] [white]{UserName}[/]" +
                                      $"\n[#c0c0c0]  Serial Code:[/] [white]{SerialCode}[/]" +
                                      $"\n[#c0c0c0]  Password:[/] [white]{Password}[/]"), VerticalAlignment.Middle));
            panelAccountInformation.Height = 11;
            panelAccountInformation.Width = 60;
            panelAccountInformation.Border(BoxBorder.Rounded);
            panelAccountInformation.BorderColor(Color.DarkGoldenrod);
            panelAccountInformation.Header("[bold #af8700 on black]Account Information[/]");
            panelAccountInformation.HeaderAlignment(Justify.Left);
            return panelAccountInformation;
        }

        public static Layout DisplayInformation()
        {
            Layout showUserRegistration = new Layout("Information")
                .SplitRows(
                    new Layout("Figlet1"),
                    new Layout("Figlet2"),
                    new Layout("Figlet3"));

            showUserRegistration["Information"].Size(35);
            showUserRegistration["Figlet1"].Size(8);
            showUserRegistration["Figlet2"].Size(7);
            showUserRegistration["Figlet3"].Size(7);

            showUserRegistration["Figlet1"].Update(new Panel(
                    new FigletText("Graef")
                    .Centered()
                    .Color(Color.White)).Expand());

            showUserRegistration["Figlet2"].Update(new Panel(
                    new FigletText("Elektro")
                    .Centered()
                    .Color(Color.Red3)).Expand());

            showUserRegistration["Figlet3"].Update(new Panel(
                    new FigletText("Grosshandel")
                    .Centered()
                    .Color(Color.DarkGoldenrod)).Expand());

            return showUserRegistration;
        }
        public static Layout ShowUserRegistrationMenu(string? firstName, string? lastName, string? firmName, string? email,
                                                        string? phoneNumber, string? userName, string? passWord, string? serialNumber)
        {
            if (firmName == null)
                firmName = "";
            if (firstName == null)
                firstName = "";
            if (lastName == null)
                lastName = "";
            if (email == null)
                email = "";
            if (phoneNumber == null)
                phoneNumber = "";
            if (userName == null)
                userName = "";
            if (passWord == null)
                passWord = "";
            if (serialNumber == null)
                serialNumber = "";

            Layout userRegistrationLayout = UserRegistrationMenu(firstName, lastName, firmName, email, phoneNumber, userName, serialNumber, passWord);
            return userRegistrationLayout;
        }
    }
}
