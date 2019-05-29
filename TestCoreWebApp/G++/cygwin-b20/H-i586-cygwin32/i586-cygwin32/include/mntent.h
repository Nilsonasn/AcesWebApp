#ifndef _MNTENT_H
#define _MNTENT_H

#ifdef __cplusplus
extern "C" {
#endif

struct mntent
  {
	const char *mnt_fsname;
	const char *mnt_dir;
	const char *mnt_type;
	const char *mnt_opts;
	int  mnt_freq;
	int  mnt_passno;
};

FILE *setmntent (const char *__filep, const char *__type);
struct mntent *getmntent (FILE *__filep);
int addmntent (FILE *__filep, const struct mntent *__mnt);
int endmntent (FILE *__filep);
char *hasmntopt (const struct mntent *__mnt, const char *__opt);

/* This next file doesn't exist, it is in the registry,
   however applications need the define to pass to
   the above calls.
*/
#ifndef MOUNTED
#define MOUNTED "/etc/mtab"
#endif
#ifdef __cplusplus
};
#endif

#endif /* _MNTENT_H */
