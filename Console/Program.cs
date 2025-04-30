using Library;



BoatRepo boats = new BoatRepo();
MemberRepo memberRepo = new MemberRepo();
BookingRepo bookingRepo = new BookingRepo();
BoatRepo boatRepo = new BoatRepo();

boatRepo.AddBoat(new Boat("Amada", "f", "g", new(2000, 12, 25), 4525412, "2,5l", 25, 1));
boatRepo.AddBoat(new Boat("Karl", "f", "44",new(2001, 10, 10), 541256, "2,5", 30, 2));

memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Lars", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Esti", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Stefan", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));



bookingRepo.AddBooking(new Booking(new(2023, 12, 31, 12, 00, 00), new(2025, 1, 1, 10, 00, 00), memberRepo.FindMemberById(1).ElementAt(0), boatRepo.FilterBoatById(1).ElementAt(0), "none"));

Console.WriteLine(bookingRepo.ReturnListAsString(bookingRepo.FindBookingByBoatName("Amanda")));

Console.WriteLine(memberRepo.ReturnListAsString(memberRepo.FindMemberByName("Toke")));

try
{
	boats.FilterBoatByName("Claus");
}
catch (NoSearhResultException noResult)
{
    Console.WriteLine(noResult.Message);
}