Coding Challenge Guidelines
===========================

Please organize, design, test, document your code as if it were
going into production, then send us a link to the hosted repository (e.g.
Github, Bitbucket...).

Functional spec
---------------

Prototype **one** of the following projects:

1. Email Service
2. Vending Machine
3. Booking Platform

The UX/UI is totally up to you. If you like, get creative and add additional
features a user might find useful!

### Email Service

Create a service that accepts the necessary information and sends emails. It
should provide an abstraction between two different email service providers.
If one of the services goes down, your service can quickly failover to
a different provider without affecting your customers.

Example Email Providers:

* [Mailgun](http://www.mailgun.com) - [Simple Send Documentation](http://documentation.mailgun.com/quickstart.html#sending-messages)
* [SendGrid](https://sendgrid.com/user/signup) - [Simple Send Documentation](https://sendgrid.com/docs/API_Reference/Web_API/mail.html)
* [Amazon SES](http://aws.amazon.com/ses/) - [Simple Send Documentation](http://docs.aws.amazon.com/ses/latest/APIReference/API_SendEmail.html)

All listed services are free to try and are pretty painless to sign up for, so
please register your own test accounts on each.

### Virtual Vending Machine

Create a virtual vendening machine. There are a selection of products with a price
and a quantity remaining. Users should put in (virtual) money and purchase an item.
After they have purchased an item, they can use the remaining money to purchase another
item or have the change returned to them. Once they are done they should see a list of
the items they have purchased.

### Booking Platform

Design a booking platform for users to rent a room. Users should see a list of rooms available
for rent and be able to click into them to see details about that room. A room at a minimum
should have the following details:

* Title
* Images
* Price
* Description
* Address
* Capacity of room

Users should then be able book that room using their email address, the dates they require and
how many people will be staying. They should not be able to book a room on a date that has
already been booked or doesn't have the capacity for the amount of people they require.


Technical spec
--------------

The architecture will be split between a back-end and a web front-end, for
instance providing a JSON in/out RESTful API. Feel free to use any other
technologies provided that the general client/service architecture is
respected.

Choose **one** of the following technical tracks that best suits your skillset:

1. **Full-stack**: include both front-end and back-end.
2. **Back-end track**: include a minimal front-end (e.g. a static view or API
   docs). Write, document and test your API as if it will be used by other
   services.
3. **Front-end track**: include a minimal back-end, or use the data service
   directly. Focus on making the interface as polished as possible.

### Back-end

We believe there is no one-size-fits-all technology. Good engineering is about
using the right tool for the right job, and constantly learning about them.
Therefore, feel free to mention in your `README` how much experience you have
with the technical stack you choose, we will take note of that when reviewing
your challenge.

Here are some technologies we are more familiar with:

* ASP.NET (core), entity framework
* NodeJS
* PHP
* Docker

You are also free to use any web framework. If you choose to use a framework
that results in boilerplate code in the repository, please detail in your
README which code was written by you (as opposed to generated code).

### Front-end

The front-end should ideally be a single page app with a single `index.html`
linking to external JS/CSS/etc. You may take this opportunity to demonstrate
your CSS3 or HTML5 knowledge. Use of a framework such as Angular, ReactJS, or VueJS
as well as a user interface framework like Bootstrap, or Semantic UI is highly recommended.
