namespace CRUD.Models
{
    public static class ClubRepository
    {
        private static List<Tbl_clb> _clubs = new List<Tbl_clb>
    {
        new Tbl_clb { Ma_clb = 1, Ten_clb = "FC A" },
        new Tbl_clb { Ma_clb = 2, Ten_clb = "FC B" },
        new Tbl_clb { Ma_clb = 3, Ten_clb = "FC C" }
    };

        private static List<Tbl_cauthu> _players = new List<Tbl_cauthu>
    {
        new Tbl_cauthu { Ma_ct = 1, Ten_ct = "Player 1", NgaySinh = new DateTime(1995, 5, 10), Que_quan = "City X", Ma_clb = 1 },
        new Tbl_cauthu { Ma_ct = 2, Ten_ct = "Player 2", NgaySinh = new DateTime(1998, 3, 21), Que_quan = "City Y", Ma_clb = 2 },
        new Tbl_cauthu { Ma_ct = 3, Ten_ct = "Player 3", NgaySinh = new DateTime(2000, 7, 15), Que_quan = "City Z", Ma_clb = 3 }
    };

        // Các phương thức CRUD cho câu lạc bộ
        public static List<Tbl_clb> GetAllClubs() => _clubs;

        public static Tbl_clb GetClubById(int id) => _clubs.FirstOrDefault(c => c.Ma_clb == id);

        public static void AddClub(Tbl_clb club)
        {
            club.Ma_clb = _clubs.Max(c => c.Ma_clb) + 1;
            _clubs.Add(club);
        }

        public static void UpdateClub(Tbl_clb club)
        {
            var existingClub = GetClubById(club.Ma_clb);
            if (existingClub != null)
            {
                existingClub.Ten_clb = club.Ten_clb;
            }
        }

        public static void DeleteClub(int id)
        {
            var club = GetClubById(id);
            if (club != null)
            {
                _clubs.Remove(club);
            }
        }

        // Các phương thức CRUD cho cầu thủ
        public static List<Tbl_cauthu> GetAllPlayers() => _players;

        public static Tbl_cauthu GetPlayerById(int id) => _players.FirstOrDefault(p => p.Ma_ct == id);

        public static void AddPlayer(Tbl_cauthu player)
        {
            player.Ma_ct = _players.Max(p => p.Ma_ct) + 1;
            _players.Add(player);
        }

        public static void UpdatePlayer(Tbl_cauthu player)
        {
            var existingPlayer = GetPlayerById(player.Ma_ct);
            if (existingPlayer != null)
            {
                existingPlayer.Ten_ct = player.Ten_ct;
                existingPlayer.NgaySinh = player.NgaySinh;
                existingPlayer.Que_quan = player.Que_quan;
                existingPlayer.Ma_clb = player.Ma_clb;
            }
        }

        public static void DeletePlayer(int id)
        {
            var player = GetPlayerById(id);
            if (player != null)
            {
                _players.Remove(player);
            }
        }
    }
}
