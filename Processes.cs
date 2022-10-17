using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;

namespace Program_Merger
{
    public static class Processes
    {
        public static string[][] programArr = new string[20][];
        public static TextBox[] startPosInput = {
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos1,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos2,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos3,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos4,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos5,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos6,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos7,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos8,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos9,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos10,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos11,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos12,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos13,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos14,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos15,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos16,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos17,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos18,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos19,
            ((MainWindow)System.Windows.Application.Current.MainWindow).startPos20
        };
        public static string[] startPos =  new string[20];
        public static string fileName;
        public static int id = 0;
        public static int row = 1;
        public static string filePath;
        public static bool saveOK = false;
        public static string saveFileName;

        public static bool checkDupes = true;

        public static void addProgram(){
            openFile(id);
            id += 1;

            Label file = new Label();
            Grid.SetRow(file, row);
            Grid.SetColumn(file, 1);
            file.Content = fileName;
            file.Width = 100;
            file.Height = 25;
            file.Foreground = Brushes.White;
            file.FontWeight = FontWeights.Bold;
            file.HorizontalAlignment = HorizontalAlignment.Right;
            file.HorizontalContentAlignment = HorizontalAlignment.Center;
            file.VerticalAlignment = VerticalAlignment.Center;

            ((MainWindow)System.Windows.Application.Current.MainWindow).ProgramList.Children.Add(file);
            row = row + 1;

            ((MainWindow)System.Windows.Application.Current.MainWindow).addAgain.IsEnabled = true;
            ((MainWindow)System.Windows.Application.Current.MainWindow).addAgain.Foreground = Brushes.White;
        }

        public static void openFile(int id){
            OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "DIN File(*.din)|*.din";
			if(openFileDialog.ShowDialog() == true)
                fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
            
            if(fileName != null){
                programArr[id] = File.ReadAllLines(filePath);

                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != (programArr[id].Count() - 1)).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != (programArr[id].Count() - 1)).ToArray();

            }
        }

        public static void addAgain(){ 

            if(fileName != null){
                programArr[id] = File.ReadAllLines(filePath);

                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != 0).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != (programArr[id].Count() - 1)).ToArray();
                programArr[id] = programArr[id].Where((source, index) => index != (programArr[id].Count() - 1)).ToArray();

            }
            id +=1;

            Label file = new Label();
            Grid.SetRow(file, row);
            Grid.SetColumn(file, 1);
            file.Content = fileName;
            file.Width = 100;
            file.Height = 25;
            file.Foreground = Brushes.White;
            file.FontWeight = FontWeights.Bold;
            file.HorizontalAlignment = HorizontalAlignment.Right;
            file.HorizontalContentAlignment = HorizontalAlignment.Center;
            file.VerticalAlignment = VerticalAlignment.Center;

            ((MainWindow)System.Windows.Application.Current.MainWindow).ProgramList.Children.Add(file);
            row = row + 1;
        }

        public static void saveFile(){

            if(((MainWindow)System.Windows.Application.Current.MainWindow).DupeCheckbox.IsChecked == true){
                checkDupes = true;
            }else{
                checkDupes = false;
            }

                for(int i = 0; i < id; i++){
                    if(startPosInput[i].Text != ""){
                        startPos[i] = startPosInput[i].Text;
                        saveOK = true;
                    } else{
                        MessageBox.Show("You must enter a start position for program " + (i + 1));
                        saveOK = false;
                        break;
                    } 
                } 
                for(int i = 0; i < id; i++){ 
                    if(checkDupes == true){
                        for(int d = 0; d < id; d++){ 
                            if(i != d){
                                if(startPosInput[i].Text == startPosInput[d].Text){
                                    MessageBox.Show("Programs " + (d+1) + " + " + (i+1) + " have the same start position.");
                                    saveOK = false;
                                    checkDupes = false;
                                    startPosInput[i].Background = Brushes.Red;
                                    startPosInput[d].Background = Brushes.Red;
                                    break;
                                }
                                else{
                                    checkDupes = true;
                                }
                            }
                            
                        else{
                        checkDupes = true;
                        break;
                    }
                    }
                } 
                }
                
             


            if(saveOK == true){
            SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "DIN File(*.din)|*.din";

            if(saveFileDialog.ShowDialog() == true)
                saveFileName = saveFileDialog.FileName;

            if(saveFileName != null)  {

            
                File.WriteAllText(saveFileName, String.Empty);

                StreamWriter streamWriter = File.AppendText(saveFileName);
                streamWriter.WriteLine("%1");
                streamWriter.Flush();
                streamWriter.Close();
                
                StreamWriter streamWriter3 = File.AppendText(saveFileName);
                for (int i = 0; i < id; i++)
                {
                    streamWriter3.WriteLine(" " + startPos[i]);

                        foreach(string value in programArr[i])
                            streamWriter3.WriteLine(value);

                    streamWriter3.WriteLine("");
                }
                streamWriter3.Flush();
                streamWriter3.Close();

                StreamWriter streamWriter2 = File.AppendText(saveFileName);
                streamWriter2.WriteLine(" M5");
                streamWriter2.WriteLine(" M30");
                streamWriter2.Flush();
                streamWriter2.Close();
                }
            }
        }

        public static void closeProgram(){
            ((MainWindow)System.Windows.Application.Current.MainWindow).Close();
        }
    }
}