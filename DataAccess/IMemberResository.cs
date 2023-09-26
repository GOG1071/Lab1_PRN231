namespace DataAccess;

using BusinessObject;

public interface IMemberRepository
{
    void AddMember(Member member);
    void UpdateMember(Member member);
    void DeleteMember(Member member);
    Member GetMemberById(int id);
    
    List<Member> GetAllMembers();
}