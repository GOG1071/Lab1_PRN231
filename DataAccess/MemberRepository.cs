namespace DataAccess;

using BusinessObject;

public class MemberRepository : IMemberRepository
{
    public void AddMember(Member member)
    {
        MemberDAO.AddMember(member);
    }
    public void UpdateMember(Member member)
    {
        MemberDAO.UpdateMember(member);
    }
    
    public void DeleteMember(Member member)
    {
        MemberDAO.DeleteMember(member);
    }
    
    public Member GetMemberById(int id)
    {
        return MemberDAO.GetMemberById(id);
    }
    
    public List<Member> GetAllMembers()
    {
        return MemberDAO.GetAllMembers();
    }
}