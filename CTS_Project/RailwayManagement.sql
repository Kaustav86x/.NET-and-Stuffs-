
/*For Roles table */
insert into Roles values('A', 'Admin');
insert into Roles values('P', 'Passenger');

/*For Users table */
insert into Users values('P1', 'Kaustav', 'Dey', 9330360552, 'deyk905@gmail.com', 'KEV1234','A');
insert into Users values('P2', 'Aaron', 'Paul', 123456780, 'ArrPaul905@gmail.com', 'Paul1238','P');


/* For TrainDetails table */
insert into TrainDetails values('T1', 'Chennai', 'Howrah', 'Duranta', '3:20 AM', '2:40 PM', '2023-06-24', 12.6, 'TCD-2');
insert into TrainDetails values('T2', 'Howrah', 'Delhi', 'Rajdhani', '4:20 AM', '5:40 AM', '2023-07-20', 11.0, 'TCD-1');


/* For Reservation table */
insert into Reservations values('R1', 'Kaustav', '2023-08-18', 'P1', 'T1');
insert into Reservations values('R2', 'Aaron', '2023-07-05', 'P2', 'T2');


/* For Class table */
insert into Classes values('C1', 'AC', 1000, 300, 'TCD-1');
insert into Classes values('C2', 'General', 800, 250, 'TCD-1');
insert into Classes values('C3', 'AC', 1000, 300, 'TCD-2'); 

/*For TrainDetailClass */
insert into TrainDetailClass values ('TCD-1');
insert into TrainDetailClass values ('TCD-2');


/* For TicketDetails table */
insert into TicketDetails values('Tick-1', 'Duranta', 'R2', 'AC', 'S10', '2023-07-19', 'defea217-df6e-4a3e-a54c-ef2dbda6375c');
insert into TicketDetails values('Tick-2', 'Karamandal', 'R1', 'General', 'S45', '2023-07-18', '95b282db-689e-4f0b-9f14-115664c90f22');


/* For Payment table*/
insert into Payments values(NEWID(), '2023-06-08', 'UPI', 'Completed', 'R1', null);
insert into Payments values(NEWID(), '2023-08-11', 'VISA', 'Completed', 'R2', null);