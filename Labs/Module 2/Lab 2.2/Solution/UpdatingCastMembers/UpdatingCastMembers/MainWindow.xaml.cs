using System.Windows;

namespace UpdatingCastMembers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly All _allCastMembers;
        private CastMember _currentCastMember;

        public MainWindow()
        {
            InitializeComponent();

            _currentCastMember = new CastMember();
            DataContext = _currentCastMember; 

            _allCastMembers = new All();
            SetCurrentCastMemberData( _allCastMembers.First() );
        }

        private void SetCurrentCastMemberData( CastMember member )
        {
            _currentCastMember.ActorName = member.ActorName;
            _currentCastMember.Character = member.Character;
            _currentCastMember.Image = member.Image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetCurrentCastMemberData( _allCastMembers.Next() );
        }
    }
}
