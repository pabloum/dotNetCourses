# Extracting Meaning from Natural Language with the Language Understanding Service (LUIS) on Microsoft Azure

## Overview

:)

## What is LUIS?

A Machine learning-based service (hosted on Microsoft Azure) to build natural language into apps, bots and IoT devices.

LUIS allows us to quickly create enterprise-ready natural language models that continuously improve.

It is design to identify valuable information in conversations and gives developers the power to integrate those conversations into their apps and bots.

*Why use LUIS?*
    1. Simple to use. It uses a technology called active learning.=> Always learning and improving.
    2. Allow developers to quickly build a custom language solution with less lines of code.
    3. Hosted on MIcrosoft Azure -> meaning secure and highly scalable.  As your solution grows, so will LUIS
    4. LUIS is enterprise ready. It supports 13 languages and plays nicely with other Azure services.

## LUIS fundamentals

LUIS -> Language Understanding Intelligent Service

LUIS is a service design to enhance your apps to better understand *natural language processing*.

LUIS uses a technology of _interactive machine learning_.

Essentially what happens acts as a translator by taking user requests and transforming them into actions for your application.

Value of LUIS:

  - Just like web apps, coversational apps rely on Controllers to route the incoming requests to the right response.
    For all incoming messages, the app intercepts them and send them off to a controller. Say that the message contains a the word secret, and you have a SecretController. If the user types private or confidential, you would need to add more logic to tell your app that Secret could be a "the same" as private or confidential.

  - The more words, the more complex a controller's logic becomes, to process that input and provide the correct response. => This is where LUIS comes to the rescue.

  LUIS can understand different words, that we can call intents, and route secret to the correct response.

  LUIS can route the different inputs where they need to go. e.g. Secret, Private or Confidential.

  LUIS moves complexity and unnecessary logic from the application layer.


## Intents (intenciones)

An intent indicates an action to take.

An intent describes the action that the user wants your application to do.

You can think of an intent as a command or, from a language perspective, a verb.

e.g.  
      "Book a flight" -> intent

Once an intent has been provided, LUIS uses highly advanced machine learning algorithms that actively learn based on intents submitted.

ML is used as LUIS needs to determine by making a best guess at what the user wants when submitting a request. If an intent is not clear, LUIS will ask the developer which intent goes with which request. And using the developer's feedback, LUIS actively learns what those intents really mean.

LUIS provides default and pre-built intents. For the developers to quickly get up and running with the service.
Pre-built intents are in a category called domains.


pre-built Domains examples:
  - Calendar
  - Communication
  - Email
  - HomeAutomation
  - Notes
  - Places - business, restaurants, addresses, public places, institutions  -
  - Restaurants Reservations
  - ToDo
  - Utilities
  - Wheather.
  - Web domain.


Intents examples:

  1.  None    -   Default intent for LUIS. When LUIS does not know what to do with the user's input
  2.  Calendar.CheckAvailability      -     Finds availability for an appointment.
  3.  Calendar.Cancel
  4.  Calendar.Confirm
  5.  Calendar.FindDuration
  6. And many more. Check LUIS documentation.


## Entities (entidades)

Remember: Intents represent actions

Then entities are the thing that your LUIS-enabled application will be taking action on.

Entities are essential for yout application to work with LUIS.

They help to improve intents that have been provided.

### Entities - Enhancing intents

  Entities allow us to narrow down the scope of user intents

  e.g. "To book a flight to Dubai"
       "To book a hotel in Romei"

       To book a flight; a hotel -> intents
       to Dubai ; in Rome  -> entities

### Entity types.

  1. Simple - It is also the most common one.
      e.g. "I want to *book a flight* to _Dubai_"
      Intent: book a flight
      Entity: Dubai

  2. Composite  -  contain multiple entities
      e.g. "I want to *book a flight* from _Dubai_ to _Doha_"
      Intent: book a flight
      Entity: Doha Dubai

  3. List  -  various entities that are all synonims of each other
      e.g. "I want to *book a flight* from _Amsterdam_"
      e.g. "I want to *book a flight* from _Schiphol_"
      e.g. "I want to *book a flight* from _AMS_"
      Intent: book a flight
      Entity: Amsterdam, Schiphol, AMS

  4. Pattern.Any   -   When trying to improve the recognition of an entity.
      e.g. "Can I *book a flight* on a _Beluga_?"
      Intent: book a flight
      entity: {TypeOfPlane}

  5. Regex   -  uses a regular expression.
      e.g. "I want to *book a flight* _VY1233_"
      Intent: book a flight
      entity: Number of flight: (VY[0-9]{4}) to determine the entity.

  6. Prebuilt   -   Provided by LUIS out-of-the-box. When needed and possible, it is better to use prebuilt thab Simple entity. Remember not to reinvent the wheel
      e.g. Number, Ordinal, Temperature, Dimension, Money, Age, Percentage, Email, URL, Phone Number

### Machine Learning Phrases.

Group of words or values with similar meaning.

Machine learned list:

For example, types of planes can be placed in this list: A380, 737, 787... etc

Good candidates fot these lists:  Industry-specific (like the airplanes) or specific corporate terminology.

Can be also used for grouping synonyms and non-synonyms  

Phrases lists are intended for terms that LUIS might have difficulty recognizing.
Phrases lists a great way to enhance LUIS's ability to recognize additional terms that otherwise would not have been recognized

## Utterances (Declaraciones)
