#!/usr/bin/python
# -*- coding: utf-8 -*-


class Quest:
    def __init__(self, uid, title, description, order, is_completed, is_active, is_available):
        self.uid = uid
        self.title = title
        self.description = description
        self.is_completed = is_completed
        self.is_active = is_active
        self.is_available = is_available
        self.depends_on = []
        self.order = order

    def set_quest_completed(self):
        self.is_completed = False
        self.is_active = False
        self.is_available = False

    def set_quest_active(self):
        self.is_active = True

    def set_quest_available(self):
        self.is_available = True

    def add_dependency(self, quest_id):
        self.depends_on.append(quest_id)

    def remove_dependency(self, quest_id):
        counter = 0
        while counter < len(self.depends_on):
            if quest_id == self.depends_on[counter]:
                del self.depends_on[counter]
            counter += 1

    def has_any_dependency(self):
        return len(self.depends_on) != 0


class QuestInvalidTypeException(Exception):
    pass
