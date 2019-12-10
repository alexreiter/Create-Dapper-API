using Create_Dapper_API.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;


namespace Create_Dapper_API.DAL
{
    public class GymMembershipRepository: IGymMembershipRepository
    {

        private IDbConnection db;

        public GymMembershipRepository()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public List<GymMembership> GetGymMemberships(int amount, string sort)
        {
            return this.db.Query<GymMembership>("SELECT TOP" + amount + "[MemberID], [MemberFirstName], [MemberLastName], [IsActive] FROM [GymMembership] ORDER BY MemberID" + sort).ToList();
        }
        public GymMembership GetSingleGymMembership(int memberId)
        {
            return db.Query<GymMembership>("SELECT[MemberID], [MemberFirstName], [MemberLastName], [IsActive] FROM [GymMembership] WHERE MemberID= @MemberID", new {MemberID = memberId}).SingleOrDefault(); 
        }
        public bool InsertGymMembership(GymMembership membership)
        {
            int rowsAffected = this.db.Execute(@"INSERT INTO GymMembership([MemberFirstName], [MemberLastName], [IsActive]) values (@MemberFirstName, @MemberLastName, @IsActive)", new {membership.MemberFirstName, membership.MemberLastName, IsActive = true });
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteGymMembership(int memberId)
        {
            int rowsAffected = this.db.Execute(@"DELETE FROM GymMembership WHERE MemberID =@MemberID", new { MemberID = memberId });
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateGymMembership(GymMembership membership)
        {
            int rowsAffected = this.db.Execute("UPDATE [GymMembership] SET [MemberFirstName] =@MemberFirstName, [MemberLastName] = @MemberLastName, [IsActive]=@IsActive WHERE MemberID=" + membership.MemberID, membership);
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

    }
}