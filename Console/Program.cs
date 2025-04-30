using Library;


Boat boat = new("Clausine", "træ", "flyder", new(2000, 01, 01), 123456, "kører godt", 20, 1);
Console.WriteLine(boat);
Console.WriteLine(boat.GetReperationsAsString());

BoatRepo boats = new BoatRepo();
MemberRepo memberRepo = new MemberRepo();


memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Lars", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Esti", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Stefan", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));




Console.WriteLine(memberRepo.ReturnListAsString(memberRepo.FindMemberByName("Toke")));

try
{
	boats.FilterBoatByName("Claus");
}
catch (NoSearhResultException noResult)
{
    Console.WriteLine(noResult.Message);
}