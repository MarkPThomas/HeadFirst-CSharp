using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest
{
    public partial class Form1 : Form
    {
        #region Properties and Fields

        private Game game;
        /// <summary>
        /// If true, the game turns are initiated by player actions.
        /// If false, then the game turns are initiated by a timer tick.
        /// </summary>
        private bool gameIsTurnBased = true;
        /// <summary>
        /// Timer tick interval in milliseconds.
        /// </summary>
        private int gameSpeed = 1000;
        private Random random = new Random();
        /// <summary>
        /// Point that exists at the center of the icon rather than its top-left origin.
        /// </summary>
        private Point iconOffset = new Point();

        private bool showBat = false;
        private bool showGhost = false;
        private bool showGhoul = false;
        private bool showWizard = false;

        private Control weaponControl = null;
        private int enemiesShown = 0;

        #endregion

        #region Initialization

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set offset of top-left corner of icon to center
            iconOffset.X = player.Width / 2;
            iconOffset.Y = player.Height / 2;

            // Initialize game object
            game = new Game(new Rectangle(78 + iconOffset.X, 57 + iconOffset.Y, 423, 161));
            game.NewLevel(random);

            // Set characters in the game
            UpdateCharacters();

            // Initialize controls
            RemoveAllInventorySelections();
            SetMoveDirections();
            SetAttackDirections();
            SetLevelLabel();
            grpbBoxPlayStyle.Visible = false;
            actionTimer.Interval = gameSpeed;
        }

        #endregion

        #region Updates and Checks

        private void UpdateCharacters()
        {
            UpdatePlayerPositionAndStats();
            UpdateEnemyPositionsAndStats();
            UpdateEnemyVisibility();

            UpdateWeaponsVisibility();
            UpdateWeaponsInventory();
            CheckWeaponPickedUp();

            CheckIfPlayerDied();
            CheckIfAllEnemiesDefeated();
        }

        private void UpdatePlayerPositionAndStats()
        {
            Point newLocation = new Point();
            newLocation.X = game.PlayerLocation.X - iconOffset.X;
            newLocation.Y = game.PlayerLocation.Y - iconOffset.Y;
            player.Location = newLocation;

            playerHitPoints.Text = game.PlayerHitPoints.ToString();
        }

        private void UpdateEnemyPositionsAndStats()
        {
            showBat = false;
            showGhost = false;
            showGhoul = false;
            showWizard = false;
            enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                Point newLocation = new Point();
                newLocation.X = enemy.Location.X - iconOffset.X;
                newLocation.Y = enemy.Location.Y - iconOffset.Y;

                if (enemy is Bat)
                {
                    bat.Location = newLocation;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = newLocation;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = newLocation;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Wizard)
                {
                    wizard.Location = newLocation;
                    wizardHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showWizard = true;
                        enemiesShown++;
                    }
                }
            }
        }

        private void UpdateEnemyVisibility()
        {
            batHitPoints.Visible = showBat;
            bat.Visible = showBat;

            ghostHitPoints.Visible = showGhost;
            ghost.Visible = showGhost;

            ghoulHitPoints.Visible = showGhoul;
            ghoul.Visible = showGhoul;

            wizardHitPoints.Visible = showWizard;
            wizard.Visible = showWizard;
        }

        private void UpdateWeaponsVisibility()
        {
            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            bomb.Visible = false;
            shield.Visible = false;
            mace.Visible = false;
            battleAxe.Visible = false;
            quiver.Visible = false;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword; break;
                case "Bow":
                    weaponControl = bow; break;
                case "Red Potion":
                    weaponControl = redPotion; break;
                case "Blue Potion":
                    weaponControl = bluePotion; break;
                case "Bomb":
                    weaponControl = bomb; break;
                case "Shield":
                    weaponControl = shield; break;
                case "Mace":
                    weaponControl = mace; break;
                case "Battle Axe":
                    weaponControl = battleAxe; break;
                case "Quiver":
                    weaponControl = quiver; break;
                default:
                    break;
            }
            if (weaponControl != null)
            {
                weaponControl.Visible = true;
            }
        }

        private void UpdateWeaponsInventory()
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                inventorySword.Visible = true;
            }
            else
            {
                inventorySword.Visible = false;
            }

            if (game.CheckPlayerInventory("Bow"))
            {
                inventoryBow.Visible = true;
            }
            else
            {
                inventoryBow.Visible = false;
            }

            if (game.CheckPlayerInventory("Bomb"))
            {
                inventoryBomb.Visible = true;
            }
            else
            {
                inventoryBomb.Visible = false;
            }

            if (game.CheckPlayerInventory("Shield"))
            {
                inventoryShield.Visible = true;
            }
            else
            {
                inventoryShield.Visible = false;
            }

            if (game.CheckPlayerInventory("Mace"))
            {
                inventoryMace.Visible = true;
            }
            else
            {
                inventoryMace.Visible = false;
            }

            if (game.CheckPlayerInventory("Battle Axe"))
            {
                inventoryBattleAxe.Visible = true;
            }
            else
            {
                inventoryBattleAxe.Visible = false;
            }

            if (game.CheckPlayerInventory("Quiver"))
            {
                inventoryQuiver.Visible = true;
            }
            else
            {
                inventoryQuiver.Visible = false;
            }

            if (game.CheckPlayerInventory("Blue Potion"))
            {
                inventoryPotionBlue.Visible = true;
            }
            else
            {
                inventoryPotionBlue.Visible = false;
            }

            if (game.CheckPlayerInventory("Red Potion"))
            {
                inventoryPotionRed.Visible = true;
            }
            else
            {
                inventoryPotionRed.Visible = false;
            }
        }

        private void CheckWeaponPickedUp()
        {
            Point newLocation = new Point();
            newLocation.X = game.WeaponInRoom.Location.X - iconOffset.X;
            newLocation.Y = game.WeaponInRoom.Location.Y - iconOffset.Y;

            weaponControl.Location = newLocation;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;
            }
            else
            {
                weaponControl.Visible = true;
            }
        }

        private void CheckIfPlayerDied()
        {
            if (game.PlayerHitPoints <= 0)
            {
                if (!gameIsTurnBased)
                {
                    StopGameClock();
                }
                
                DialogResult gameEnd = MessageBox.Show("You died. \n\nWould you like to restart the current level?", "c'est la vie",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (gameEnd == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    game.RestartLevel(random);
                    SetLevelLabel();
                    UpdateCharacters();
                    if (!gameIsTurnBased)
                    {
                        StartGameClock();
                    }
                }
            }
        }

        private void CheckIfAllEnemiesDefeated()
        {
            if (enemiesShown < 1)
            {
                if (!gameIsTurnBased)
                {
                    StopGameClock();
                }
                MessageBox.Show("You have defeated the enemies on this level.");
                game.NewLevel(random);
                if (game.Level > 10)
                {
                    if (!gameIsTurnBased)
                    {
                        StopGameClock();
                    }
                    this.Dispose();
                    this.Close();
                }
                SetLevelLabel();
                UpdateCharacters();
                if (!gameIsTurnBased)
                {
                    StartGameClock();
                }
            }
        }
        #endregion

        #region Inventory
        private void SelectInventoryItem(string weaponName, PictureBox weaponPicture)
        {
            if (game.CheckPlayerInventory(weaponName))
            {
                game.Equip(weaponName);

                RemoveAllInventorySelections();
                weaponPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void RemoveAllInventorySelections()
        {
            inventoryBattleAxe.BorderStyle = BorderStyle.None;
            inventoryBomb.BorderStyle = BorderStyle.None;
            inventoryBow.BorderStyle = BorderStyle.None;
            inventoryMace.BorderStyle = BorderStyle.None;
            inventoryPotionBlue.BorderStyle = BorderStyle.None;
            inventoryPotionRed.BorderStyle = BorderStyle.None;
            inventoryQuiver.BorderStyle = BorderStyle.None;
            inventoryShield.BorderStyle = BorderStyle.None;
            inventorySword.BorderStyle = BorderStyle.None;
        }

        private void SetInventorySelection(string inventoryItem)
        {
            switch (inventoryItem)
            {
                case "Sword":
                    SelectInventoryItem(inventoryItem, inventorySword);
                    SetAttackDirections();
                    break;

                case "Bow":
                    SelectInventoryItem(inventoryItem, inventoryBow);
                    SetAttackDirections();
                    break;

                case "Mace":
                    SelectInventoryItem(inventoryItem, inventoryMace);
                    SetAttackDirections();
                    break;

                case "Blue Potion":
                    SelectInventoryItem(inventoryItem, inventoryPotionBlue);
                    SetAttackPotion();
                    break;

                case "Red Potion":
                    SelectInventoryItem(inventoryItem, inventoryPotionRed);
                    SetAttackPotion();
                    break;

                case "Battle Axe":
                    SelectInventoryItem(inventoryItem, inventoryBattleAxe);
                    SetAttackDirections();
                    break;

                case "Quiver":
                    SelectInventoryItem(inventoryItem, inventoryQuiver);
                    SetAttackDirections();
                    break;

                case "Bomb":
                    SelectInventoryItem(inventoryItem, inventoryBomb);
                    SetAttackBomb();
                    break;

                case "Shield":
                    SelectInventoryItem(inventoryItem, inventoryShield);
                    SetAttackShield();
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Game Turn Style
        private void SetGameStyleControls()
        {
            // Pause game until selection is made
            if (!gameIsTurnBased && !grpbBoxPlayStyle.Visible)
            {
                StopGameClock();
            }
            else if (!gameIsTurnBased && grpbBoxPlayStyle.Visible)
            {
                StartGameClock();
                moveUp.Select();
            }

            // Display temporary control
            SetGroupBox(!grpbBoxPlayStyle.Visible);
        }

        private void SetGroupBox(bool isVisible)
        {
            grpbBoxPlayStyle.Visible = isVisible;
            SetControlsEnabled(!isVisible);
        }

        private void SetGameStyle()
        {
            if (turnBased.Checked)
            {
                gameIsTurnBased = true;
            }
            else
            {
                gameIsTurnBased = false;
            }

            SetGroupBox(false);

            // Unpause game once selection is made
            if (gameIsTurnBased)
            {
                StartGameClock();
            }
        }

        private void StartGameClock()
        {
            actionTimer.Interval = gameSpeed;
            actionTimer.Start();
        }

        private void StopGameClock()
        {
            actionTimer.Stop();
        }

        private void actionTimer_Tick(object sender, EventArgs e)
        {
            // Enemies and magic weapons move independent of player and according to time tick
            if (!gameIsTurnBased)
            {
                game.Move(Direction.None, random);
                UpdateCharacters();
            }
        }
        #endregion

        #region Movements and Actions

        /// <summary>
        /// Player moves in the direction of the keyboard arrow pressed.
        /// If 'Shift' is also pressed, the player attacks in the direction of the keyboard arrow pressed.
        /// </summary>
        /// <param name="e"></param>
        private void KeyBoardAction(KeyEventArgs e)
        {
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        GameAttack(Direction.Up);
                        break;
                    case Keys.Left:
                        GameAttack(Direction.Left);
                        break;
                    case Keys.Down:
                        GameAttack(Direction.Down);
                        break;
                    case Keys.Right:
                        GameAttack(Direction.Right);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        GameMove(Direction.Up);
                        break;
                    case Keys.Left:
                        GameMove(Direction.Left);
                        break;
                    case Keys.Down:
                        GameMove(Direction.Down);
                        break;
                    case Keys.Right:
                        GameMove(Direction.Right);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Player moves in the direction of the mouse click.
        /// </summary>
        private void SingleClickAction(MouseEventArgs e)
        {
            if (game.Boundaries.Contains(e.Location))
            {
                Direction moveDirection = game.OrientPlayer(e.Location);
                if (moveDirection != Direction.None)
                {
                    GameMove(moveDirection);
                }
                else
                {
                    MessageBox.Show("oops");
                }
            }
        }

        /// <summary>
        /// Player attacks in the direction of the mouse click.
        /// </summary>
        private void DoubleClickAction(MouseEventArgs e)
        {
            if (game.Boundaries.Contains(e.Location))
            {
                Direction attackDirection = game.OrientPlayer(e.Location);
                if (attackDirection != Direction.None)
                {
                    GameAttack(attackDirection);
                }
            }
        }

        private void GameMove(Direction direction)
        {
            if (gameIsTurnBased)
            {
                game.Move(direction, random);
            }
            else
            // Only the player moves since other movement occurs with timer tick.
            {
                game.PlayerMove(direction);
            }
            UpdateCharacters();
        }

        private void GameAttack(Direction direction)
        {
            if (gameIsTurnBased)
            {
                game.Attack(direction, random);
            }
            else
            // Only the player attacks since other movement occurs with timer tick.
            {
                game.PlayerAttack(direction, random);
            }
            UpdateCharacters();
        }

        #endregion

        #region Form and Control Behavior
        private void SetControlsEnabled(bool enableControls)
        {
            moveUp.Enabled = enableControls;
            moveLeft.Enabled = enableControls;
            moveDown.Enabled = enableControls;
            moveRight.Enabled = enableControls;

            attackUp.Enabled = enableControls;
            attackLeft.Enabled = enableControls;
            attackDown.Enabled = enableControls;
            attackRight.Enabled = enableControls;

            inventoryBattleAxe.Enabled = enableControls;
            inventoryBomb.Enabled = enableControls;
            inventoryBow.Enabled = enableControls;
            inventoryMace.Enabled = enableControls;
            inventoryPotionBlue.Enabled = enableControls;
            inventoryPotionRed.Enabled = enableControls;
            inventoryQuiver.Enabled = enableControls;
            inventoryShield.Enabled = enableControls;
            inventorySword.Enabled = enableControls;
        }

        private void SetLevelLabel()
        {
            lblLevel.Text = "Level " + game.Level.ToString();
        }

        private void SetMoveDirections()
        {
            moveUp.Text = "↑";
            moveLeft.Text = "←";
            moveDown.Text = "↓";
            moveRight.Text = "→";
        }

        private void SetAttackDirections()
        {
            attackUp.Visible = true;
            attackLeft.Visible = true;
            attackDown.Visible = true;
            attackRight.Visible = true;

            attackUp.Text = "↑";
            attackLeft.Text = "←";
            attackDown.Text = "↓";
            attackRight.Text = "→";

            ResizeAttackUpButton(23);

        }

        private void ResizeAttackUpButton(int buttonWidth)
        {
            // Keep attack button centered while resizing
            Point attackUpCenter = attackUp.Location;
            attackUpCenter.X += attackUp.Width / 2;           // Set to center of button
            attackUp.Width = buttonWidth;
            attackUpCenter.X -= attackUp.Width / 2;         // Set to target control origin
            attackUp.Location = attackUpCenter;
        }

        private void SetAttackSingleButton()
        {
            attackLeft.Visible = false;
            attackDown.Visible = false;
            attackRight.Visible = false;
        }

        private void SetAttackPotion()
        {
            attackUp.Text = "Drink";
            ResizeAttackUpButton(45);
            SetAttackSingleButton();
        }

        private void SetAttackBomb()
        {
            attackUp.Text = "Explode";
            ResizeAttackUpButton(54);
            SetAttackSingleButton();
        }

        private void SetAttackShield()
        {
            attackUp.Text = "Jab Shield";
            ResizeAttackUpButton(64);
            SetAttackSingleButton();
        }

        /// <summary>
        /// The arrow keys must be disabled from all controls in the form in order for them to operate as  controls.
        /// Might be why 'A','W','D','S' are usually used for game navigation.
        /// </summary>
        /// <param name="e"></param>
        private void DisableArrowKeysFocus(PreviewKeyDownEventArgs e)
        {
            Keys key = e.KeyCode;

            if (key == Keys.Up ||
                key == Keys.Left ||
                key == Keys.Down ||
                key == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }
        #endregion

        #region Control Event Methods

        // Set Game Turn Style
        //  Buttons
        private void btnSetPlayStyle_Click(object sender, EventArgs e)
        {
            SetGameStyleControls();
        }

        //  Radio Buttons
        private void turnBased_CheckedChanged(object sender, EventArgs e)
        {
            SetGameStyle();
        }
        private void actionGame_CheckedChanged(object sender, EventArgs e)
        {
            SetGameStyle();
        }
        private void turnBased_Click(object sender, EventArgs e)
        {
            SetGameStyle();
        }
        private void actionGame_Click(object sender, EventArgs e)
        {
            SetGameStyle();
        }


        // Movements and Attacks
        //  Buttons
        private void moveUp_Click(object sender, EventArgs e)
        {
            GameMove(Direction.Up);
        }
        private void moveLeft_Click(object sender, EventArgs e)
        {
            GameMove(Direction.Left);
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            GameMove(Direction.Down);
        }
        private void moveRight_Click(object sender, EventArgs e)
        {
            GameMove(Direction.Right);
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            GameAttack(Direction.Up);
        }
        private void attackLeft_Click(object sender, EventArgs e)
        {
            GameAttack(Direction.Left);
        }
        private void attackDown_Click(object sender, EventArgs e)
        {
            GameAttack(Direction.Down);
        }
        private void attackRight_Click(object sender, EventArgs e)
        {
            GameAttack(Direction.Right);
        }

        //  Mouse
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            SingleClickAction(e);
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickAction(e);
        }

        //  Keyboard
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyBoardAction(e);
        }


        // Inventory Actions
        //  Buttons
        private void inventorySword_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Sword");
        }
        private void inventoryBow_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Bow");
        }
        private void inventoryMace_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Mace");
        }
        private void inventoryPotionBlue_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Blue Potion");
        }
        private void inventoryPotionRed_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Red Potion");
        }
        private void inventoryBattleAxe_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Battle Axe");
        }
        private void inventoryQuiver_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Quiver");
        }
        private void inventoryBomb_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Bomb");
        }
        private void inventoryShield_Click(object sender, EventArgs e)
        {
            SetInventorySelection("Shield");
        }


        // Disable Arrow Keys from Selecting Controls
        //  Keyboard
        private void moveUp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void moveLeft_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void moveDown_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void moveRight_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void attackUp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void attackLeft_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void attackDown_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        private void attackRight_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DisableArrowKeysFocus(e);
        }
        #endregion
    }
}
