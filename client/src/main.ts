import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));

// entry point for angular application
// like program.cs in c#
// appConfig is the configuaration of this app
// while App is the root component of this app