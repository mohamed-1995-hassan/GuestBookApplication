# GuestBookApplication
I select a clean Architecture to implement All the service of the task   and separate the application to 4 layers (Application, Service, Repository, Data)

I Implement the security using the sign of HTTP context that allow all user to see the home page and when to try create ,
update or delete without the sign it will redirect to log in page and
after logging in If I the owner of the message the system will allow me to do the crud operation, otherwise the website will display an unauthenticated ted message.
