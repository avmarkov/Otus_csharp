### Скрипт заполнения таблиц данными 

```sql
insert into course(name, datestart, dateend, price)
values('C# Developer. Professional', '2023-01-31', '2023-09-11', 67000),
      ('PostgreSQL для администраторов баз данных и разработчиков', '2022-10-17', '2023-03-17', 100000),
      ('C# ASP.NET Core разработчик', '2023-05-31', '2023-10-31', 100000),
      ('PostgreSQL Cloud Solutions',  '2023-04-27', '2023-09-27', 65000),
      ('C# Developer. Basic', '2023-04-26', '2023-09-25', 50000);
	  
	  
insert into student(firstname, lastname, surname, email, phone, enrollmentdate, courseid)
values('Иван', 'Иванов', 'Иванович', 'ivanov_ii@mail.ru', '676767', '2021-01-01', 6),
      ('Петр', 'Петров', 'Петрович', 'petrov_pp@mail.ru', '767654',  '2022-11-01',  7),
      ('Алексей', 'Алексеев', 'Алексеевич', 'alekseev_aa@mail.ru', '768768', '2021-12-01', 8),
      ('Семен',  'Семенов',  'Семенович', 'semenov_ss@mail.ru', '7867866', '2022-10-01', 9),
	  ('Роман',  'Романов',  'Романович',  'romanov_rr@mail.ru', null,  '2023-02-01',  null );
	  
insert into teacher(firstname, lastname, surname, email, phone, education, job, courseid)
values('Иван', 'Сидоров', 'Петрович', 'sidorov_ip@mail.ru', '676767', 'Кандидат технических наук', 'Яндекс', 6),
      ('Петр', 'Кузнецов', 'Александрович', 'kuznetzov_pf@mail.ru', '676767',  'Кандидат технических наук', 'Сбербанк', 7),
      ('Алексей', 'Соколов', 'Петрович', 'sokolov_ap@mail.ru', '676767', 'Кандидат технических наук', 'Отус', 8),
      ('Семен', 'Смирнов', 'Иванович', 'smirnov_si@mail.ru', '676767', 'Кандидат технических наук' , 'Майл РУ', 9),
      ('Романов', 'Попов', 'Михайлович', 'romanov_pm@mail.ru', '676767', 'Кандидат технических наук', 'ВТБ', null );
```