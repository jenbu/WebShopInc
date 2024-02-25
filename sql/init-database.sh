password="pasSord123"

sleep 10s 

echo Starting
for i in {1..50};
do
	/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P $password -d master -i /sql/createDatabase.sql
    if [ $? -eq 0 ]
    then
        echo "createDatabase.sql completed"
        break
    else
        echo "not ready yet..."
        # sleep 1s
    fi
done

echo Create tables
for filename in /sql/table/*.sql; 
do
	echo run $filename
	/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P $password -d master -i $filename
done

echo Insert data
for filename in /sql/data/*.sql; 
do
	echo run $filename
	/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P $password -d master -i $filename
done