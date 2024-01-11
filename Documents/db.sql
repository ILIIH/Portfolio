CREATE TABLE `courses` (
  `course_id` integer PRIMARY KEY,
  `course_name` char(100),
  `course_img_link` char(200)
);

CREATE TABLE `course_details` (
  `course_id` integer PRIMARY KEY,
  `duration` DataTime,
  `tasks_amount` integer,
  `online_classes_amount` integer,
  `offline_classes_amount` integer,
  `course_description` char(1000),
  `tutor_id` integer
);

CREATE TABLE `course_tutors` (
  `tutor_id` integer PRIMARY KEY,
  `tutor_name` cahr(100),
  `tutor_img_link` char(200)
);

CREATE TABLE `projects` (
  `project_id` integer PRIMARY KEY,
  `tutor_id` integer,
  `project_name` char(100),
  `project_photo` char(200)
);

CREATE TABLE `project_reps` (
  `reps_id` integer PRIMARY KEY,
  `project_id` integer,
  `reps_name` char(100)
);

CREATE TABLE `plan_items` (
  `plan_id` integer PRIMARY KEY,
  `course_id` integer,
  `plan_item_name` char(100)
);

CREATE TABLE `project_tools` (
  `project_tool_id` integer PRIMARY KEY,
  `project_id` integer,
  `tool_name` char(40),
  `image_link_name` char(40)
);

CREATE TABLE `skills` (
  `skill_id` integer PRIMARY KEY,
  `tutor_id` integer,
  `skill_name` char(100),
  `skill_photo` char(100)
);

ALTER TABLE `course_details` ADD FOREIGN KEY (`course_id`) REFERENCES `courses` (`course_id`);

ALTER TABLE `plan_items` ADD FOREIGN KEY (`course_id`) REFERENCES `course_details` (`course_id`);

ALTER TABLE `course_details` ADD FOREIGN KEY (`tutor_id`) REFERENCES `course_tutors` (`tutor_id`);

ALTER TABLE `projects` ADD FOREIGN KEY (`tutor_id`) REFERENCES `course_tutors` (`tutor_id`);

ALTER TABLE `project_reps` ADD FOREIGN KEY (`project_id`) REFERENCES `projects` (`project_id`);

ALTER TABLE `project_tools` ADD FOREIGN KEY (`project_id`) REFERENCES `projects` (`project_id`);

ALTER TABLE `skills` ADD FOREIGN KEY (`tutor_id`) REFERENCES `course_tutors` (`tutor_id`);
