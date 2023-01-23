Connection string do bazy danych trzeba ustawić ręcznie w pliku appsettings.json.
W pliku 'SqlDbCreate.sql' znajduje się skrypt tworzący tabele, przy okazji dodając użytkonika 'admin'.

W pliku 'SeatsAutoInsert.py' znajduje się skrypt wstawiający do bazy wiersze z siedzeniami. W tym pliku również trzeba ustawić parametry takie jak 'host', 'database', 'user' oraz 'password'. Dodatkowo wymaga on do działania biblioteki 'psycopg2'.
