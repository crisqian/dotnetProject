import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  // other services required to start this app
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    // the reason why private http = inject(HttpClient) don't report error
    provideHttpClient()
    // by default zoneless provider is provided in angular 22
  ]
};


