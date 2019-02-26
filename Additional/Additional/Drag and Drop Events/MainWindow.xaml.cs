using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wincubate.Module12.Slide11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDragInProgress = false;
        private Point _start;
        ListBoxItem _objectToMove = null;

        public MainWindow()
        {
           InitializeComponent();
        }

        private void OnPreviewMouseDown( object sender, MouseButtonEventArgs e )
        {
           AddToEventSenderView( "PreviewMouseDown", sender );

           _start = e.GetPosition( null );
           _objectToMove = listBox1.SelectedItem as ListBoxItem;
        }

        private void OnPreviewMouseMove( object sender, MouseEventArgs e )
        {
            //AddToEventSenderView( "PreviewMouseMove", sender );

            Point currentMousePosition = e.GetPosition( null );
            Vector mouseMovedDifference = _start - currentMousePosition;

            if( e.LeftButton == MouseButtonState.Pressed && _isDragInProgress == false )
            {
                // Has mouse moved "enough" for it to be a drag?
                if( Math.Abs( mouseMovedDifference.X ) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs( mouseMovedDifference.Y ) > SystemParameters.MinimumVerticalDragDistance )
                {
                    // For simplicity drag the selected item of the listbox
                    ListBox listBox = sender as ListBox;
                    if( _objectToMove != null )
                    {
                        // Initialize the Drag and Drop operation
                        _isDragInProgress = true;
                        DataObject data = new DataObject( typeof( ListBoxItem ), _objectToMove );
                        DragDropEffects result = DragDrop.DoDragDrop(
                            listBox as DependencyObject,
                            data,
                            DragDropEffects.Move | DragDropEffects.Copy );

                        if( ( result & DragDropEffects.Move ) == DragDropEffects.Move )
                        {
                            // Remove item being moved
                            listBox.Items.Remove( _objectToMove );
                        }

                        _isDragInProgress = false;
                    }
                }
            }
        }

        private void OnDragEnter( object sender, DragEventArgs e )
        {
            AddToEventSenderView( "DragOver", sender );
        }

        private void OnDrop( object sender, DragEventArgs e )
        {
            AddToEventSenderView( "Drop", sender );

            ListBox receivingListBox = sender as ListBox;

            if( e.Data.GetDataPresent( typeof( ListBoxItem ) ) )
            {
                ListBoxItem item = e.Data.GetData( typeof( ListBoxItem ) ) as ListBoxItem;

                // If CTRL is down drag was a move. Otherwise it was a copy
                if( ( e.KeyStates & DragDropKeyStates.ControlKey ) == DragDropKeyStates.ControlKey )
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                }

                // Add dropped item to receiving ListBox
                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = item.Content;
                receivingListBox.Items.Add( newItem );
            }
        }
        
        private void OnGiveFeedback( object sender, GiveFeedbackEventArgs e )
        {
            AddToEventSenderView( "GiveFeedback", sender );

            // Change mouse cursor or do other stuff
        }

        private void OnQueryContinueDrag( object sender, QueryContinueDragEventArgs e )
        {
            AddToEventSenderView( "QueryContinueDrag", sender );

            // Check whether drag should terminate or go on...
            if( ( e.KeyStates & DragDropKeyStates.ShiftKey ) == DragDropKeyStates.ShiftKey )
            {
                e.Action = DragAction.Cancel;
                e.Handled = true;
            }
        }

        private void OnDragOver( object sender, DragEventArgs e )
        {
            AddToEventSenderView( "DragOver", sender );

            // Check if drag was from a ListBox
            if ( e.Data.GetDataPresent( typeof( ListBoxItem ) ) )
            {
               ListBoxItem item = e.Data.GetData( typeof( ListBoxItem ) ) as ListBoxItem;

               if ( sender == item.Parent )
               {
                  e.Effects = DragDropEffects.None;
                  e.Handled = true;
               }
            }
        }

        private void OnDragLeave( object sender, DragEventArgs e )
        {
            AddToEventSenderView( "DragLeave", sender );
        }

        private void AddToEventSenderView( string eventName, object sender )
        {
            Control element = sender as Control;

            lstEvents.Items.Add( string.Format( "{0} @ {1}",
                eventName,
                element.Name )
            );
        }

        private void btnClearEvents_Click( object sender, RoutedEventArgs e )
        {
            lstEvents.Items.Clear();
        }
    }
}
