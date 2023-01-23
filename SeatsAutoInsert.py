import string
import psycopg2


CONNECTION_STRING = ''
WIDTH = 12
HEIGHT = 7
LETTERS = list(string.ascii_uppercase)
ID_CINEMA_HALL = 1


#conn = psycopg2.connect('host=localhost port=5432 Database=cinemadb username=postgres password=admin;')
conn = psycopg2.connect(
    host='localhost',
    database='cinemadb',
    user='postgres',
    password='admin'
)
cur = conn.cursor()

for i in range(HEIGHT):
    for j in range(WIDTH):
        code = LETTERS[i] + str(j + 1)
        print(code, f'COORDS: X:{j}, Y:{i}')
        cur.execute(f'INSERT INTO "Seats"("Code", "IdCinemaHall", "CoordX", "CoordY") VALUES(\'{code}\', {ID_CINEMA_HALL}, {j}, {i})')

conn.commit()
