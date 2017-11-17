using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Threading;
using Android.Content.Res;
using Plugin.DeviceOrientation;
using Xamarin.Forms;

namespace TheGovernator
{
    [Activity(Label = "TheGovernator")]
    public class MainActivity : Activity
    {
        protected const string SAVE_SELECTION = "";

        protected int current_selection = 0;

        // Do not access these by name - use buttons array + the index
        // They are added to the array in this order (littlefriend is 0, likehome 1, etc.)
        // This is standard order for all data structures in this app
        protected ImageView button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello, background;

        protected ImageView[] buttons;

        protected int[,] backgrounds;

        // Each item in soundEffects has a voice line
        // SE_TEST is for testing purposes only
        protected MediaPlayer playerSE;

        protected Dictionary<int, int> soundEffects;

        protected const int SE_TEST = Resource.Raw.SE_test;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            ActionBar.Hide();

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

            // Access buttons through this array after this line!
            buttons = new ImageView[] { button_littlefriend, button_likehome, button_itsme,
            button_deadpeople, button_dreams, button_neverhungry, button_wakeup,
            button_chocolates, button_gohome, button_theforce, button_precious,
            button_hello };

            // Access backgrounds through this 2D array after this line!
            // First index is 0 for landscape, 1 for portrait
            // Second index is standard ID for the quote
            backgrounds = new int[,] { { Resource.Drawable.little_friend_LS,
                                         Resource.Drawable.like_home_LS,
                                         Resource.Drawable.its_me_LS,
                                         Resource.Drawable.dead_people_LS,
                                         Resource.Drawable.dreams_LS,
                                         Resource.Drawable.never_hungry_LS,
                                         Resource.Drawable.wake_up_LS,
                                         Resource.Drawable.chocolates_LS,
                                         Resource.Drawable.go_home_LS,
                                         Resource.Drawable.force_LS,
                                         Resource.Drawable.precious_LS,
                                         Resource.Drawable.hello_LS }, 
                                       { Resource.Drawable.little_friend_P,
                                         Resource.Drawable.like_home_P,
                                         Resource.Drawable.its_me_P,
                                         Resource.Drawable.dead_people_P,
                                         Resource.Drawable.dreams_P,
                                         Resource.Drawable.never_hungry_P,
                                         Resource.Drawable.wake_up_P,
                                         Resource.Drawable.chocolates_P,
                                         Resource.Drawable.go_home_P,
                                         Resource.Drawable.force_P,
                                         Resource.Drawable.precious_P,
                                         Resource.Drawable.hello_P } };

            // Access sounds through this Dictionary after this line!
            soundEffects = new Dictionary<int, int>(); // TODO: Create sounds, replace placeholders
            soundEffects.Add(0, Resource.Raw.SE_test); // little_friend
            soundEffects.Add(1, Resource.Raw.SE_test); // like_home
            soundEffects.Add(2, Resource.Raw.SE_test); // its_me
            soundEffects.Add(3, Resource.Raw.SE_test); // deadpeople
            soundEffects.Add(4, Resource.Raw.SE_test); // dreams
            soundEffects.Add(5, Resource.Raw.SE_test); // neverhungry
            soundEffects.Add(6, Resource.Raw.SE_test); // wakeup
            soundEffects.Add(7, Resource.Raw.SE_test); // chocolates
            soundEffects.Add(8, Resource.Raw.SE_test); // gohome
            soundEffects.Add(9, Resource.Raw.SE_test); // theforce
            soundEffects.Add(10, Resource.Raw.SE_test);// precious
            soundEffects.Add(11, Resource.Raw.SE_test);// hello

            // Attaching background to its view
            background = FindViewById<ImageView>(Resource.Id.background);

            // Restore saved state
            if (savedInstanceState != null)
            {
                current_selection = savedInstanceState.GetInt(SAVE_SELECTION);
                ChangeSelection(buttons[current_selection], false);
            }
            else
            {
                ChangeSelection(buttons[0], false);
            }

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
            ChangeSelection(buttons[11], true);
        }

        private void Button_theforce_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[9], true);
        }

        private void Button_gohome_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[8], true);
        }

        private void Button_wakeup_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[6], true);
        }

        private void Button_precious_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[10], true);
        }

        private void Button_neverhungry_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[5], true);
        }

        private void Button_dreams_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[4], true);
        }

        private void Button_itsme_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[2], true);
        }

        private void Button_deadpeople_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[3], true);
        }

        private void Button_littlefriend_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[0], true);
        }

        private void Button_likehome_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[1], true);
        }

        private void Button_chocolates_Click(object sender, System.EventArgs e)
        {
            ChangeSelection(buttons[7], true);
        }

        public void StartPlayer(int fileID)
        {
            playerSE = MediaPlayer.Create(this, fileID);
            if(playerSE.IsPlaying)
                playerSE.Stop();

            Thread audiothread = new Thread(new ThreadStart(playerSE.Start));
            audiothread.Start();
        }

        /*  Transition the background
         *  backgroundvalue is 0 - 11 for backgrounds[,]
         *  orientation is 0 for landscape, 1 for portrait in backgrounds[,]  */
        public void ChangeBackground(int backgroundvalue, int orientation)
        {
            background.SetImageResource(backgrounds[orientation, backgroundvalue]);
        }

        /*  Actions to perform when a button is selected
         *  bool instantplay is if audio playback should begin when selected  */
        public void ChangeSelection(ImageView selection, bool instantplay)
        {
            int playchoice = 0; // This assignment shuts up the compiler, it'll never matter
            if (instantplay)
            {
                // button_littlefriend
                if (selection == buttons[0])
                {
                    current_selection = 0;
                    playchoice = (soundEffects[0]);
                }
                // button_likehome
                else if (selection == buttons[1])
                {
                    current_selection = 1;
                    playchoice = (soundEffects[1]);
                }
                // button_itsme
                else if (selection == buttons[2])
                {
                    current_selection = 2;
                    playchoice = (soundEffects[2]);
                }
                // button_deadpeople
                else if (selection == buttons[3])
                {
                    current_selection = 3;
                    playchoice = (soundEffects[3]);
                }
                // button_dreams
                else if (selection == buttons[4])
                {
                    current_selection = 4;
                    playchoice = (soundEffects[4]);
                }
                // button_neverhungry
                else if (selection == buttons[5])
                {
                    current_selection = 5;
                    playchoice = (soundEffects[5]);
                }
                // button_wakeup
                else if (selection == buttons[6])
                {
                    current_selection = 6;
                    playchoice = (soundEffects[6]);
                }
                // button_chocolates
                else if (selection == buttons[7])
                {
                    current_selection = 7;
                    playchoice = (soundEffects[7]);
                }
                // button_gohome
                else if (selection == buttons[8])
                {
                    current_selection = 8;
                    playchoice = (soundEffects[8]);
                }
                // button_theforce
                else if (selection == buttons[9])
                {
                    current_selection = 9;
                    playchoice = (soundEffects[9]);
                }
                // button_precious
                else if (selection == buttons[10])
                {
                    current_selection = 10;
                    playchoice = (soundEffects[10]);
                }
                // button_hello
                else if (selection == buttons[11])
                {
                    current_selection = 11;
                    playchoice = (soundEffects[11]);
                }
                StartPlayer(playchoice);
            } // TODO: Fade background
            if (WindowManager.DefaultDisplay.Orientation == 1 || WindowManager.DefaultDisplay.Orientation == 3)
            {
                ChangeBackground(current_selection, 0);
            }
            else
            {
                ChangeBackground(current_selection, 1);
            }
        }
    }
}

