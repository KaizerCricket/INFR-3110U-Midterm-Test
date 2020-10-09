#pragma once
#include "CheckpointTimeLogger.h"

#ifdef __cplusplus
extern "C"
{
#endif

	//Resets logger
	PLUGIN_API void ResetLogger();

	//Saves the most recent checkpoint time
	PLUGIN_API  void SaveCheckpointTime(float intervals);

	//Gets total time to complete maze
	PLUGIN_API float GetTotalTime();
	//Gets checkpoint time at index
	PLUGIN_API float GetCheckpointTime(int index);
	//Gets the number of saved checkpoints
	PLUGIN_API int GetNumCheckpoints();

#ifdef __cplusplus
}
#endif