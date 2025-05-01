using Library;



BoatRepo boats = new BoatRepo();
MemberRepo memberRepo = new MemberRepo();
BookingRepo bookingRepo = new BookingRepo();
BoatRepo boatRepo = new BoatRepo();

boatRepo.AddBoat(new Boat("Amada", "f", "g", new(2000, 12, 25), 4525412, "2,5l", 25, 1));
boatRepo.AddBoat(new Boat("Karl", "f", "44",new(2001, 10, 10), 541256, "2,5", 30, 2));
boatRepo.AddBoat(new Boat("Sandra", "f", "h", new(1990, 5, 24), 521524, "3,5", 30, 3));

memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Lars", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Esti", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Stefan", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));



bookingRepo.AddBooking(new Booking(new(2023, 12, 31, 12, 00, 00), new(2025, 1, 1, 10, 00, 00), memberRepo.FilterMemberById(1), boatRepo.FilterBoatById(1).ElementAt(0), "ingen"));
bookingRepo.AddBooking(new Booking(new(2024, 12, 25, 10, 00, 00), new(2025, 1, 1, 10, 00, 00), memberRepo.FilterMemberById(2), boatRepo.FilterBoatById(2).ElementAt(0), "ingen"));


Console.WriteLine(bookingRepo.ReturnListAsString(bookingRepo.FilterBookingByBoatName("Amanda")));

Console.WriteLine(memberRepo.ReturnListAsString(memberRepo.FilterMemberByName("Toke")));

try
{
	boats.FilterBoatByName("Claus");
}
catch (NoSearhResultException noResult)
{
    Console.WriteLine(noResult.Message);
}

Console.WriteLine(bookingRepo.FilterBookingById(1).ToString());

Console.WriteLine(bookingRepo.FilterBookingById(2).ToString());