namespace DataAccess;

using System.Data;
using System.Runtime.CompilerServices;
using BusinessObject;

public class MemberDAO
{
    public static List<Member> GetAllMembers()
    {
        List<Member> members = new();
        try
        {
            using var context = new EStoreDbContext();
            members = context.Members.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return members;
    }
    
    public static Member GetMemberById(int id)
    {
        Member member = null;
        try
        {
            using var context = new EStoreDbContext();
            member = context.Members.Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return member;
    }
    
    public static void AddMember(Member member)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Members.Add(member);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void UpdateMember(Member member)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Members.Update(member);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void DeleteMember(Member member)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Members.Remove(member);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void DeleteMemberById(int id)
    {
        try
        {
            using var context = new EStoreDbContext();
            var       member  = context.Members.Find(id);
            DeleteMember(member);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}