using Android.App;
using Android.Widget;
using Android.OS;

namespace TheGovernator
{
    [Activity(Label = "TheGovernator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected ImageView button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello, background;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Attaching objects to their views
            button_chocolates = (ImageView) FindViewById(Resource.Id.button_chocolates);
            button_littlefriend = (ImageView)FindViewById(Resource.Id.button_littlefriend);
            button_likehome = (ImageView)FindViewById(Resource.Id.button_likehome);
            button_itsme = (ImageView)FindViewById(Resource.Id.button_itsme);
            button_deadpeople = (ImageView)FindViewById(Resource.Id.button_deadpeople);
            button_dreams = (ImageView)FindViewById(Resource.Id.button_dreams);
            button_neverhungry = (ImageView)FindViewById(Resource.Id.button_neverhungry);
            button_wakeup = (ImageView)FindViewById(Resource.Id.button_wakeup);
            button_gohome = (ImageView)FindViewById(Resource.Id.button_gohome);
            button_theforce = (ImageView)FindViewById(Resource.Id.button_theforce);
            button_precious = (ImageView)FindViewById(Resource.Id.button_precious);
            button_hello = (ImageView)FindViewById(Resource.Id.button_hello);

            // New ImageView for background image
            background = new ImageView(ApplicationContext);

            // Setting Button delegates
            button_chocolates.Click += Button_chocolates_Click;
            button_likehome.Click += Button_likehome_Click;
            button_littlefriend.Click += Button_littlefriend_Click;
            button_deadpeople.Click += Button_deadpeople_Click;
            button_itsme.Click += Button_itsme_Click;
            button_dreams.Click += Button_dreams_Click;
            button_neverhungry.Click += Button_neverhungry_Click;
            button_precious.Click += Button_precious_Click;
            button_wakeup.Click += Button_wakeup_Click;
            button_gohome.Click += Button_gohome_Click;
            button_theforce.Click += Button_theforce_Click;
            button_hello.Click += Button_hello_Click;
        }

        private void Button_hello_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_theforce_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_gohome_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_wakeup_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_precious_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_neverhungry_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_dreams_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_itsme_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_deadpeople_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_littlefriend_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_likehome_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_chocolates_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

