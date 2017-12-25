# AccountingBook
Project for Training Epam

### Инструкция по запуску:

1) Для создания базы данных запустить скрипт  **AccountingBookDataBaseScripts\Database\initDataBase.sql** (при необходимости запустить  **AccountingBookDataBaseScripts\UserscreateLoginName.sql** - для создания имени входа на сервер)
2) Изменить connectionStrings в  **Service\AccountingBookService\Web.config**.
3) Запустить **Service\AccountingBookService** через Visual Studio или развернуть на IIS.
4) Изменить адреса в **Web\AccountingBookWeb.Web\Web.config** на адрес развернутого сервиса.
Изменить адрес в  **Web\AccountingBookData\Service References**.
5) Запустить **Web\AccountingBookWeb** через Visual Studio или развернуть на IIS.
6) Дать разрешение пулу сервиса на запись в папку.  **iss apppool\your_apppool_name**

### Аккаунты для входа:

| role | name | password |
| ------ | ------ |  ------ |
| **admin** | kostya | 123456 |
| **editor** | maxim | 123456 |

