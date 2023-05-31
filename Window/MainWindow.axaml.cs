using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using McGreeninator_UI.Classes;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace McGreeninator_UI
{
    public partial class MainWindow : Window
    {
        public cScheduler scheduler;
        public cPumpHandler pumpHandler;
        public cSerialHandler serialHandler;
        public cSettings settings;

        public MainWindow()
        {

            scheduler = new cScheduler();
            pumpHandler = new cPumpHandler();
            //serialHandler = new cSerialHandler();
            settings = new cSettings();

            InitializeComponent();

            

            
        }



        //------------------------------------------------------------------------------- //
        // ===================================== HOME =================================== //
        // ------------------------------------------------------------------------------ //

        // buttons

        /// <summary>
        /// Toggles the Grow light on or off
        /// Resets on the next scheduled light event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_ToggleLight_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("toggle light pressed");
        }

        public void btn_water_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("water button clicked");
        }

        //------------------------------------------------------------------------------- //
        // ===================================== Settings =============================== //
        // ------------------------------------------------------------------------------ //
        public ObservableCollection<string> lst_pumpTime_items = new ObservableCollection<string>();
        public ObservableCollection<string> lst_lightTime_items = new ObservableCollection<string>();

        // sliders
        public event EventHandler<AvaloniaPropertyChangedEventArgs> TemperaturePropertyChanged;

        public void sld_temp_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if(lbl_Temperature != null) lbl_Temperature.Content = sld_Temperature.Value.ToString();
        }

        public void sld_humidity_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (lbl_Humidity != null) lbl_Humidity.Content = sld_Humidity.Value.ToString();
        }

        public void sld_pH_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (lbl_pH != null) lbl_pH.Content = sld_pH.Value.ToString();
        }

        public void sld_potassium_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (lbl_Potassium != null) lbl_Potassium.Content = sld_Potassium.Value.ToString();
        }

        public void sld_phosphorus_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (lbl_Phosphorus != null) lbl_Phosphorus.Content = sld_Phosphorus.Value.ToString();
        }

        public void sld_nitrogen_changed(object sender, AvaloniaPropertyChangedEventArgs e)
        {

            if (lbl_Nitrogen != null) lbl_Nitrogen.Content = sld_Nitrogen.Value.ToString();
        }



        //buttons

        public void btn_saveSettings_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("save settings pressed");
        }
        public void btn_lightAddTime_Click(object sender, RoutedEventArgs e)
        {

            addToConsole("light add time pressed");
            // value in text box set to list box and update the scheduler

            lst_lightTime_items.Add("Item: " + lst_lightTime_items.Count + " Start: " + txt_lightStart.Text + " End: " + txt_lightEnd.Text);
            
            lst_lightSchedule.Items = lst_lightTime_items;

            updateScheduleClass();

        }
        public void btn_lightRemoveTime_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("light remove time pressed");

            lst_lightTime_items.RemoveAt(lst_lightSchedule.SelectedIndex);

            lst_lightSchedule.Items = lst_lightTime_items;

            updateScheduleClass();
        }
        public void btn_pumpAddTime_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("pump add time pressed");

            lst_pumpTime_items.Add("Item: " + lst_pumpTime_items.Count + " Start: " + txt_pumpStart.Text + " Amount: " + txt_pumpAmount.Text);

            lst_pumpSchedule.Items = lst_pumpTime_items;

            updateScheduleClass();
        }
        public void btn_pumpRemoveTime_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("pump remove time pressed");

            lst_pumpTime_items.RemoveAt(lst_pumpSchedule.SelectedIndex);

            lst_pumpSchedule.Items = lst_pumpTime_items;

            updateScheduleClass();
        }

        // scheduler 
        public void updateScheduleClass()
        {
            settings.CurrentSettings.Scheduler.pumpList.Clear();
            for (int i = 0; i < lst_pumpTime_items.Count; i++)
            {
                settings.CurrentSettings.Scheduler.pumpList.Add(parseListBox(lst_pumpTime_items[i]));
            }
            settings.CurrentSettings.Scheduler.lightList.Clear();
            for (int i = 0; i < lst_lightTime_items.Count; i++)
            {
                settings.CurrentSettings.Scheduler.lightList.Add(parseListBox(lst_lightTime_items[i]));
            }

            addToConsole("schedule updated");
        }

        public timeRange parseListBox(string listboxEntry)
        {
            
            int start = 0;
            int end = 0;

            string[] split = listboxEntry.Split(" ");
            if (split.Length > 0)
            {
                string[] startSplit = split[3].Split(":");
                start = int.Parse(startSplit[0] + startSplit[1]);

                if (split[4].Contains("End:"))
                {
                    string[] endSplit = split[5].Split(":");
                    end = int.Parse(endSplit[0] + endSplit[1]);
                }
                else if (split[4].Contains("Amount:"))
                {
                    
                    end = int.Parse(split[5]);
                }

            }

            addToConsole("entry parsed " + start + ":" + end);
            timeRange range = new timeRange(start,end);
            return range;
        }
        //------------------------------------------------------------------------------- //
        // ===================================== Debug ===================================//
        // ------------------------------------------------------------------------------ //

        public ObservableCollection<string> lst_console_items = new ObservableCollection<string>();

        // buttons
        public void btn_updateSensors_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("button update sensor pressed");
        }

        public void btn_resetSerial_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("button reset serial clicked");
        }

        public void btn_sendMcuReset_Click(object sender, RoutedEventArgs e)
        {
            addToConsole("button mcu reset clicked");
        }

        // Debug Console
        public void addToConsole(string item)
        {
            lst_console_items.Add(item);
            if (lst_Console != null) lst_Console.Items = lst_console_items;
        }
    }
}