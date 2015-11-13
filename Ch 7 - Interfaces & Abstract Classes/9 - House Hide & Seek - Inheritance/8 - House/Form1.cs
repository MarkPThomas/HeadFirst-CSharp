using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        RoomWithHidingPlace diningRoom;
        Room stairs;
        RoomWithHidingPlace upstairsHallway;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;

        Opponent opponent;

        private Location currentLocation;
        private int moves;
        private string currentHidingPlaceChecked;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            ResetGame(false);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob", "inside the closet");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door", "in the cabinet");
            diningRoom = new RoomWithHidingPlace("Dining Room", "a crystal chandelier", "in the tall armoire");
            stairs = new Room("Stairs", "a wooden bannister");
            upstairsHallway = new RoomWithHidingPlace("Upstairs Hallway","a picture of a dog","in the closet");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "a sink and a toilet", "in the shower");

            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
            garden = new OutsideWithHidingPlace("Garden", false, "inside the shed");
            driveway = new OutsideWithHidingPlace("Driveway", false, "in the garage");

            livingRoom.Exits = new Location[] { diningRoom, stairs };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            kitchen.Exits = new Location[] {diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            upstairsHallway.Exits = new Location[] { masterBedroom, secondBedroom, bathroom, stairs };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            frontYard.Exits = new Location[] { backYard, garden, driveway };
            backYard.Exits = new Location[] { frontYard, garden, driveway };
            garden.Exits = new Location[] { frontYard, backYard };
            driveway.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            opponent = new Opponent(frontYard);     
        }

        private void MoveToANewLocation(Location newLocation)
        {
            moves++;
            currentLocation = newLocation;
            
            RedrawForm();            
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            int locationIndex = exits.SelectedIndex;
            Location nextLocation = currentLocation.Exits[locationIndex];
            MoveToANewLocation(nextLocation);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void check_Click(object sender, EventArgs e)
        {
            moves++;
            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                RedrawForm();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;

            for (int i = 1; i <= 10; i++)
            {
                description.Text = i + "... ";
                opponent.Move();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }

            description.Text = "Ready or not, here I come!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            goHere.Visible = true;
            exits.Visible = true;
            MoveToANewLocation(livingRoom);
        }

        private void RedrawForm()
        {
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
                exits.Items.Add(currentLocation.Exits[i].Name);
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description + "\r\n(move #" + moves + ")";

            if (currentLocation is IHidingPlace)
            {
                check.Visible = true;
                IHidingPlace currentHidingPlace = currentLocation as IHidingPlace;
                currentHidingPlaceChecked = currentHidingPlace.HidingPlaceName;
                check.Text = "Check " + currentHidingPlaceChecked;
            }
            else
                check.Visible = false;

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void ResetGame(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show("You found me in " + moves + " moves!");
                description.Text = "You found your opponent in " + moves + " moves! He was hiding " + currentHidingPlaceChecked + ".";
            }

            opponent = new Opponent(frontYard);
            moves = 0;

            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
            
            hide.Visible = true;        
        }


    }
}
