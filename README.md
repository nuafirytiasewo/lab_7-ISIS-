# Лабораторная работа 7 по дисциплине "Инструментальные средства информационных систем".
Установил Visual Studio 2022 
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/4565b4de-4e1b-424b-b15b-30465d9976a3)

Установил необходимые пакеты для разработки
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/ee539cc2-a1b0-4d98-8a4e-5caefb199d7c)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/b5874b77-cb05-4361-b5af-473660cb579f)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/e9ba76c3-0df3-444c-b70c-a985e9d5e7b1)

 
 
Выбрал шаблон ASP.NET Web Application (.NET Framework)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/2eba4f75-734b-4ab6-a4a8-da2edd9ca109)

 
Выбрал .NET Framework 4.8 в новом окне
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/7482f4ec-afaf-4054-9dff-e9401f0fa3dd)

 
В следующем окне выбрал WebAPI
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/750fb149-42fe-442c-b1ba-128438363cbe)

Установил EntityFramework
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/ea170d2a-2efa-4e50-90af-81665aff0471)

В Models добавляю новый предмет
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/92ad6fd5-5370-4129-8358-2d35158f0696)

Это будет ADO.NET Entity Data Model
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/ba5ad1c3-89ad-4143-8ab1-13c551bdc8f6)

Выбрал подход Code first
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/1ebc0b48-b67f-4255-a82e-706770f006db)

Зашел в СУБД MSSQL Server 2022
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/856af012-9ffb-459d-8455-990c5c50f29d)

Создал таблицы в БД lab_7
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/81e4674c-abf3-498f-af9d-e99f54e6db79)

Добавил связи, внешние ключи к таблицам (Дампы будут предоставлены)
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/ac3ef4d4-b9f0-4f38-901d-e9384c1eea07)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/5c7d4c4d-edb1-404a-a2f7-cd56bfb145ec)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/2225c6d8-9e56-4e60-b7b8-4b6bd293926c)

 
 
После наполнения таблиц бд данными, подключился в новом окне в Visual Studio к созданной БД
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/2425218e-fabb-4ccc-98d1-eed00334ed44)

Собственно, принимаем строку подключения
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/59b9a061-2c6f-4747-91d3-fcb488227bd4)

Конвертируем данные из бд в проект
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/473eae87-4c13-48e1-9313-92fe0596b186)

Запустим приложение, которое создали
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/6e30c0bc-91ee-4fcc-8cc3-49b41303d1d1)

Запустился браузер с созданным приложением
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/583ba854-07d2-4f53-828e-784223bbce12)

Для начала нужно создать модели (CRUD) для таблиц из базы данных 
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/6561dd36-f13c-403f-afe6-486fecd44c21)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/15b2a51d-6b25-4fce-897d-a171b5b04f88)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/d6afc6c8-541b-4083-be90-82b6dadaa8e6)
Создался контроллер и представление
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/877a1989-c2e6-4f7d-94cd-305def05b91b)
Запускаем представление и видим, что сформировался список районов
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/d9b76356-6bdd-471e-9dd2-1244a2b11058)
Создадим CRUD для остальных таблиц. Для всех таблиц можно сделать быстрое отображение на главной странице.
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/af845c7f-3113-40e8-8ca0-d8e9d2f451c5)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/80a5537e-bebe-4c07-b6df-f16b5f31e26a)
Для выполнения первого задания нам нужно создать контроллер, который будет содержать в себе весь код для остальных заданий.
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/34934e1f-3643-4dd1-88f1-40e17dbe65dd)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/e78c26be-622b-42d8-a3bb-66e74b74d895)
Добавим код для выполнения 2.1 задания
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/a93929d3-0266-43aa-8838-cbc79f7cf3c3)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/8ffc0ae2-5a11-4448-bbbf-fc17c6b5d118)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/f17cff34-6119-4694-8f0a-a788007c27d3)
Добавим представление и отображение кнопки для перехода на 2.1 задание на главный экран
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/352d1351-90d3-4883-bd77-d7d078eb580b)
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/add635d6-14d3-4f7a-9433-17224c8665dc)
Запустим и посмотрим что получилось
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/6e1f2d45-9ec4-4a7f-bac7-be4a655c3b11)
Введем в фильтры данные в первом задании
 ![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/56803e8d-b2bf-4b8f-8234-5421d44c27dc)

И получили действительные данные из БД
![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/fd1cef34-1138-440a-9bd0-3c3d0f38ee1f)

![image](https://github.com/nuafirytiasewo/lab_7-ISIS-/assets/103138302/5382f7cf-1a3b-444d-b209-5500c2d08fc7)

  
