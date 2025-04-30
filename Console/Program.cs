using Library;


Boat boat = new("Clausine", "træ", "flyder", new(2000, 01, 01), 123456, "kører godt", 20, 1);
boat.AddReperation("Fikset masten", new(2020, 02, 03));
boat.AddReperation("Fikset sejl", new(2021, 05, 16));
Console.WriteLine(boat);
Console.WriteLine(boat.GetReperationsAsString());


MemberRepo memberRepo = new MemberRepo();


memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Lars", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Esti", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Stefan", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));




Console.WriteLine(memberRepo.ReturnListAsString(memberRepo.FindMemberByName("Toke")));