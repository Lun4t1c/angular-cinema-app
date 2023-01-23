CREATE TABLE "Users"(
	"Id" SERIAL PRIMARY KEY,
	"Email" VARCHAR(50) UNIQUE NOT NULL,
	"Password" VARCHAR(50) NOT NULL,
	"IsAdmin" BOOLEAN NOT NULL DEFAULT false
);

CREATE TABLE "CinemaHalls"(
	"Id" SERIAL PRIMARY KEY,
	"Code" VARCHAR(4) UNIQUE NOT NULL
);

CREATE TABLE "Seats"(
	"Id" SERIAL PRIMARY KEY,
	"Code" VARCHAR(4) UNIQUE NOT NULL,
	"IdCinemaHall" INT NOT NULL,
	"CoordX" smallint NOT NULL,
	"CoordY" smallint NOT NULL,
	CONSTRAINT fk_cinema_hall FOREIGN KEY("IdCinemaHall") REFERENCES "CinemaHalls"("Id")
);

CREATE TABLE "MovieShowings"(
	"Id" SERIAL PRIMARY KEY,
	"BeginDate" TIMESTAMP NOT NULL,
	"IdMovie" INT NOT NULL,
	"IdCinemaHall" INT NOT NULL,
	CONSTRAINT fk_cinema_hall FOREIGN KEY("IdCinemaHall") REFERENCES "CinemaHalls"("Id")
);

CREATE TABLE "Reservations"(
	"Id" SERIAL PRIMARY KEY,
	"IdUser" INT NOT NULL,
	"IdMovieShowing" INT NOT NULL,
	CONSTRAINT fk_user FOREIGN KEY("IdUser") REFERENCES "Users"("Id"),
	CONSTRAINT fk_movie_showing FOREIGN KEY("IdMovieShowing") REFERENCES "MovieShowings"("Id")
);

CREATE TABLE "ReservationSeats"(
	"IdReservation" INT NOT NULL,
	"IdSeat" INT NOT NULL,
	CONSTRAINT fk_reservation FOREIGN KEY("IdReservation") REFERENCES "Reservations"("Id"),
	CONSTRAINT fk_seat FOREIGN KEY("IdSeat") REFERENCES "Seats"("Id"),
	PRIMARY KEY("IdReservation", "IdSeat")
);

INSERT INTO "Users"("Email", "Password", "IsAdmin") VALUES('admin', 'admin', true);
