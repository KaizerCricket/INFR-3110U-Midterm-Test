#pragma once
#ifndef __PLUGIN_SETTINGS__
#define __PLUGIN_SETTINGS__
#ifdef PLUGIN_EXPORT
#define PLUGIN_API __declspec(dllexport)
#elif PLUGIN_IMPORT
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif
#endif /* defind (__PLUGIN_SETTINGS__) */
