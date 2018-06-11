# Tree Task Organizer

Are you looking for the most versatile task and note organizer app?
One that could allow be customized to the tiniest detail?

Give **Tree Task Organizer** a try!

It's a free open-source utility app that gives you a virtual space to take any
notes. It is designed with both approachable simplicity and extensive customizability in mind.

Note organization is based on a hierarchy similar to a directed
graph - a note can be a child of any other note. Thanks to this you can
categorize your jottings any way you want to.


## Top features (WIP)

This simple yet powerful note system is not released yet,
but at the moment is planned to have following features
(those marked with :+1: are planned to be ready for the first release in June):
- :+1: tree-like relations between entries allow for infinite organization possibilities
- :+1: two view modes - tree mode and detail mode - let you easily explore your notes
- customizable note content and appearance enable you to express ideas easily and precisely
- tasks give you a simple way to set a reminder and always stay up-to-date
with your responsibilities
- configurable widgets improve content accessibility even further
- all tasks seamlessly synchronize thanks to external storage providers (Google Drive)
- :+1: focus on support for Android
  - possible future releases for Windows, iOS and Linux
- :+1: no ads


## Codebase

This app is being brought to life thanks to many wonderful technologies,
including:

- .NET platform
- Xamarin
- Visual Studio
- C# language
- external synchronization mean providers
  - Google Drive
- (probably some DB support - or other data format that would simplify sync process - will also
come in handy during synchronization development)


## Example use case

#### Scenario: *Adding a new note*

1. The user enters the app and is presented with easily navigable component containing his notes
2. The user navigates to target parent task and expresses will to create a new task
3. The system provides a set of ways to customize task content,
appearance and task hierarchy and shows a live
[WYSIWYG](https://en.wikipedia.org/wiki/WYSIWYG) preview
of the task as it would be shown in detail view
4. The user modifies task content as he wishes until it meets his expectations
5. The user signals that he finished customizing the task
6. The system saves 

###### Alternative flows:

<div>
4A. The user decides to abandon scenario
<ol type="1">
  <li>
    The system discards changes
  </li>
</ol>
</div>


