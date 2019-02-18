select 
 m.First_Name as "employee", 
 e.First_Name as "manager" 
from 
 Employees e join Employees m 
on 
 e.Id = m.Managers_Id;