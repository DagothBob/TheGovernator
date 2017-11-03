using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System;
using Android.Content.Res;

namespace TheGovernator
{
    [Activity(Label = "TheGovernator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected const string SAVE_SELECTION = "";

        protected int current_selection = 0;

        // Do not access these by name - use buttons array + the index
        protected ImageView button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello, background;

        protected ImageView[] buttons;

        protected MediaPlayer playerSE;
        protected int[] soundEffects;

        protected const int SE_TEST = Resource.Raw.SE_test;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Console.WriteLine("DEBUG: CONSOLE.WRITELINE TEST");

            // Attaching objects to their views
            button_chocolates = FindViewById<ImageView>(Resource.Id.button_chocolates);
            button_littlefriend = FindViewById<ImageView>(Resource.Id.button_littlefriend);
            button_likehome = FindViewById<ImageView>(Resource.Id.button_likehome);
            button_itsme = FindViewById<ImageView>(Resource.Id.button_itsme);
            button_deadpeople = FindViewById<ImageView>(Resource.Id.button_deadpeople);
            button_dreams = FindViewById<ImageView>(Resource.Id.button_dreams);
            button_neverhungry = FindViewById<ImageView>(Resource.Id.button_neverhungry);
            button_wakeup = FindViewById<ImageView>(Resource.Id.button_wakeup);
            button_gohome = FindViewById<ImageView>(Resource.Id.button_gohome);
            button_theforce = FindViewById<ImageView>(Resource.Id.button_theforce);
            button_precious = FindViewById<ImageView>(Resource.Id.button_precious);
            button_hello = FindViewById<ImageView>(Resource.Id.button_hello);

            buttons = new ImageView[] { button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello };

            soundEffects = new int[] { Resource.Raw.SE_test, Resource.Raw.SE_test,
                Resource.Raw.SE_test, Resource.Raw.SE_test, Resource.Raw.SE_test,
                Resource.Raw.SE_test, Resource.Raw.SE_test, Resource.Raw.SE_test,
                Resource.Raw.SE_test, Resource.Raw.SE_test, Resource.Raw.SE_test,
                Resource.Raw.SE_test, Resource.Raw.SE_test };

            // Attaching background to its view
            background = FindViewById<ImageView>(Resource.Id.background);

            // Restore saved state
            if (savedInstanceState != null)
            {
                current_selection = savedInstanceState.GetInt(SAVE_SELECTION);
                ChangeSelection(buttons[current_selection], false);
            }

            // Initial background (will not play sound)

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

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(SAVE_SELECTION, current_selection);
        }

        private void Button_hello_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_theforce_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_gohome_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_wakeup_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_precious_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_neverhungry_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_dreams_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_itsme_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_deadpeople_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_littlefriend_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_likehome_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        private void Button_chocolates_Click(object sender, System.EventArgs e)
        {
            StartPlayer(soundEffects[12]);
        }

        // TODO: Create all sound files, ensure state is uninterrupted, etc.
        public void StartPlayer(int fileID)
        {
            playerSE = MediaPlayer.Create(this, fileID);
            if(playerSE.IsPlaying)
                playerSE.Stop();

            playerSE.Start();
        }

        /*  Transition the background  */
        public void ChangeBackground(int backgroundchange)
        {
            background.SetImageResource(Resource.Drawable.chocolates_P);
        }

        /*  Actions to perform when a button is selected  */
        public void ChangeSelection(ImageView selection, bool instantplay)
        {
            if (instantplay)
            {
                // button_littlefriend
                if (selection == buttons[0])
                {

                }
                // button_likehome
                else if (selection == buttons[1])
                {

                }
                // button_itsme
                else if (selection == buttons[2])
                {

                }
                // button_deadpeople
                else if (selection == buttons[3])
                {

                }
                // button_dreams
                else if (selection == buttons[4])
                {

                }
                // button_neverhungry
                else if (selection == buttons[5])
                {

                }
                // button_wakeup
                else if (selection == buttons[6])
                {

                }
                // button_chocolates
                else if (selection == buttons[7])
                {

                }
                // button_gohome
                else if (selection == buttons[8])
                {

                }
                // button_theforce
                else if (selection == buttons[9])
                {

                }
                // button_precious
                else if (selection == buttons[10])
                {

                }
                // button_hello
                else if (selection == buttons[11])
                {

                }
            }
        }
    }
}

