#!/usr/bin/python
# -*- coding: utf-8 -*-

import datetime as dt
import core.model.Chapter as Ch


class World:
    def __init__(self):
        self.latest_save = None
        self.chapters = []

    def save_game(self):
        self.latest_save = dt.datetime.now()

    def add_chapter(self, chapter):
        if type(chapter) != Ch.Chapter:
            raise Ch.ChapterInvalidTypeException
        self.chapters.append(chapter)

    def get_chapter(self, order):
        for item in self.chapters:
            if item.order == order:
                return item
        raise Ch.ChapterNotFoundException
